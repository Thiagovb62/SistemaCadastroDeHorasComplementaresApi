using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;
using SistemaCadastroDeHorasApi.Models.ENUMS;
using SistemaCadastroDeHorasApi.Repositories;
using SistemaCadastroDeHorasApi.Repositories.Contracts;
using SistemaCadastroDeHorasApi.Services.Contracts;

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

    public async Task AddAsync(Atividades atividade, int matricula, IFormFile comprovante)
    {
        var (arquivo, nomeArquivo, tipoArquivo) = _comprovanteService.ConvertComprovante(comprovante);
        atividade.comprovante = arquivo;
        atividade.nomeArquivo = nomeArquivo;
        atividade.tipoArquivo = tipoArquivo;
        
        await _atividadeUsuarioRepositoryRepository.AddAsync(atividade,matricula );
         
    }

    public Task DeleteByAtividadeIdAsync(Guid id)
    {
        return _atividadesRepository.DeleteAsync(id);
    }
}