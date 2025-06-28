using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;
using SistemaCadastroDeHorasApi.Models.ENUMS;
using SistemaCadastroDeHorasApi.Repositories;
using SistemaCadastroDeHorasApi.Repositories.Contracts;
using SistemaCadastroDeHorasApi.Services.Contracts;
using SistemaCadastroDeHorasApi.Services.Factory;

namespace SistemaCadastroDeHorasApi.Services;

public class AtividadeUsuarioService: IAtividadeUsuarioService
{
    
    private readonly IAtividadeUsuarioRepository _atividadeUsuarioRepositoryRepository;
    private readonly IAtividadesRepository _atividadesRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IComprovanteService _comprovanteService;
    public AtividadeUsuarioService(IAtividadeUsuarioRepository atividadeUsuarioRepositoryRepository, IAtividadesRepository atividadesRepository, IUsuarioRepository usuarioRepository, IComprovanteService comprovanteAuxiliary)
    {
        _atividadeUsuarioRepositoryRepository = atividadeUsuarioRepositoryRepository;
        _atividadesRepository = atividadesRepository;
        _usuarioRepository = usuarioRepository;
        _comprovanteService = comprovanteAuxiliary;
    }

    public Task<IEnumerable<ResAtividadeUsario>> GetAllByUserMatriculaAsync(int matricula)
    {
        var atividades =  _atividadesRepository.GetAllByUserMatriculaAsync(matricula).Result;
        var user =  _usuarioRepository.GetByMatriculaAsync(matricula).Result;
        
        return Task.FromResult(atividades.Select(a => new ResAtividadeUsario(
            new ResUserDTO(
                user.Nome,
                user.SemestreDeIngresso,
                user.Matricula
            ),
            new ResAtividadeDTO(
                a.Id,
                a.dataInicio,
                a.dataFim,
                 a.TipoAtividade.nome.ToString(),
                a.TipoParticipacao.nome.ToString(),
                a.pais,
                a.titulo,
                a.nomeInstituicao,
                a.isExecUfc,
                a.cargaHoraria,
                a.qtdHorasUtilizadas, 
                a.cnpj ?? string.Empty
            ),
            a.nomeArquivo,
            a.tipoArquivo
        )));
            
    }

    public void AddAsync(ReqAtividadeUsuarioDTO dto, int matricula, IFormFile comprovante)
    {
        AtividadeFactory atividadeFactory =  new AtividadeFactory( 
            _usuarioRepository,
            _comprovanteService,
            _atividadeUsuarioRepositoryRepository
        );
        atividadeFactory.CriarAtividade(dto, matricula, comprovante);
        
    }
    public async Task<string> UpdateAsync(ReqUpdateAtividadeDTO dto, Guid atividadeId)
    {
        var atividade = await _atividadesRepository.GetByIdAsync(atividadeId);
        
        if (atividade == null)
        {
            throw new KeyNotFoundException($"Atividade com ID {atividadeId} não encontrada.");
        }

        var usuario = await _usuarioRepository.GetByIdAsync(atividade.UsuarioId);
        if (atividade == null)
        {
            throw new KeyNotFoundException($"Atividade com ID {atividadeId} não encontrada.");
        }

        if (dto.TipoAtividadeId != 0)
        {
            atividade.TipoAtividadeId = dto.TipoAtividadeId;
        }
        if (dto.TipoParticipacaoId != 0)
        {
            atividade.TipoParticipacaoId = dto.TipoParticipacaoId;
        }
        atividade.pais = dto.pais ?? atividade.pais;    
        atividade.titulo = dto.titulo ?? atividade.titulo;
        atividade.nomeInstituicao = dto.nomeInstituicao ?? atividade.nomeInstituicao;
        atividade.cnpj = dto.cnpj ?? atividade.cnpj;
        atividade.dataInicio = dto.DataInicio != default ? dto.DataInicio : atividade.dataInicio;
        atividade.dataFim = dto.DataFim != default ? dto.DataFim : atividade.dataFim;
        atividade.isExecUfc = dto.isExecUfc ?? atividade.isExecUfc;
        atividade.cargaHoraria = dto.cargaHoraria != 0 ? dto.cargaHoraria : atividade.cargaHoraria;
        atividade.qtdHorasUtilizadas = dto.qtdHorasUtilizadas != 0 ? dto.qtdHorasUtilizadas : atividade.qtdHorasUtilizadas;
        
        if (dto.comprovante != null)
        {
            var (arquivo, nomeArquivo, tipoArquivo) = _comprovanteService.ConvertComprovante(dto.comprovante);
            atividade.comprovante = arquivo;
            atividade.nomeArquivo = nomeArquivo;
            atividade.tipoArquivo = tipoArquivo;
        }

        await _atividadesRepository.UpdateAsync(atividade);
        
        return $"Atividade atualizada com sucesso!.";
        
    }

    public Task DeleteByAtividadeIdAsync(Guid id)
    {
        return _atividadesRepository.DeleteAsync(id);
    }
}