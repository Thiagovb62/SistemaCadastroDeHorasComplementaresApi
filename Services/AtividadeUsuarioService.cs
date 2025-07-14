using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;
using SistemaCadastroDeHorasApi.Models.ENUMS;
using SistemaCadastroDeHorasApi.Repositories;
using SistemaCadastroDeHorasApi.Repositories.Contracts;
using SistemaCadastroDeHorasApi.Services.Contracts;
using SistemaCadastroDeHorasApi.Services.Factory;

namespace SistemaCadastroDeHorasApi.Services;

public class AtividadeUsuarioService : IAtividadeUsuarioService
{
    private readonly IAtividadeUsuarioRepository _atividadeUsuarioRepositoryRepository;
    private readonly IAtividadesRepository _atividadesRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IComprovanteService _comprovanteService;

    public AtividadeUsuarioService(IAtividadeUsuarioRepository atividadeUsuarioRepositoryRepository,
        IAtividadesRepository atividadesRepository, IUsuarioRepository usuarioRepository,
        IComprovanteService comprovanteAuxiliary)
    {
        _atividadeUsuarioRepositoryRepository = atividadeUsuarioRepositoryRepository;
        _atividadesRepository = atividadesRepository;
        _usuarioRepository = usuarioRepository;
        _comprovanteService = comprovanteAuxiliary;
    }
    
    public CategoriaAtividadeComplementarEnum? ObterTipoAtividadePorNome(int  codigo)
    {
        return CategoriaAtividadeComplementarEnumExtensions.FromCode(codigo);
    }
 
    public Task<IEnumerable<ResAtividadeUsario>> GetAllByUserMatriculaAsync(int matricula)
    {
        var user = _usuarioRepository.GetByMatriculaAsync(matricula).Result;
        var atividades = _atividadesRepository.GetAllByUserMatriculaAsync(matricula).Result;

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

    public int GetTipoAtividadeComplementarByIdAsync(int matricula, int codigo)
    {
        var atividades = _atividadesRepository.GetAllByUserMatriculaAsync(matricula).Result;
        var tipoAtividade = ObterTipoAtividadePorNome(codigo);
        var qtdHorasUtilizadas = 0;
        var atividade = atividades.FirstOrDefault(a => a.categoriaAtividadeComplementarHoras == tipoAtividade);
        if (atividade != null)
        {
            qtdHorasUtilizadas = atividade.qtdHorasUtilizadas;
        }

        return qtdHorasUtilizadas;
    }

    public async Task<IEnumerable<ResHoraDetailsDTO>> GetHorasDeatailsByMatricula(int matricula)
    {
        var usuario = await _usuarioRepository.GetByMatriculaAsync(matricula);
        if (usuario == null)
        {
            throw new KeyNotFoundException($"Usuário com matrícula {matricula} não encontrado.");
        }
        
        var listaDetalhesHoras = new List<ResHoraDetailsDTO>();
        var nomesCategorias = Enum.GetNames(typeof(CategoriaAtividadeComplementarEnum));


        for (int i = 0; i < nomesCategorias.Length; i++)
        {
            var (horasTotais, horasRestantes) = GetHorasFromUsuarioPorCategoria(usuario, i.ToString());

            var nomeAtual = ObterTipoAtividadePorNome(i);

            var horasUtilizadas = this.GetTipoAtividadeComplementarByIdAsync(matricula, i);
                

            var detalheDto = new ResHoraDetailsDTO(
                nomeAtual.GetDescription(),
                horasTotais,
                horasUtilizadas: horasUtilizadas,
                horasRestantes,
                horasTotaisCurso: usuario.HorasTotais,
                horasRestantesTotaisCurso: usuario.horasRestantesTotais
            );
            listaDetalhesHoras.Add(detalheDto);
        }

        return listaDetalhesHoras;
    }

    private (int horasTotais, int horasRestantes) GetHorasFromUsuarioPorCategoria(Usuario usuario, string nomeCategoria)
    {
        if (Enum.TryParse<CategoriaAtividadeComplementarEnum>(nomeCategoria, out var categoriaEnum))
        {
            switch (categoriaEnum)
            {
                case CategoriaAtividadeComplementarEnum.IniciacaoDocenciaPesquisaExtensao:
                    return (usuario.HorasTotaisDeIniciacaoADocenciaOuVivenciaOuExtensão,
                        usuario.horasRestantesDeIniciacaoADocenciaOuVivenciaOuExtensão);
                case CategoriaAtividadeComplementarEnum.AtividadesArtisticoCulturaisEsportivas:
                    return (usuario.HorasTotaisDeAtividadesArtisticoCulturaisEEsportivas,
                        usuario.horasRestantesDeAtividadesArtisticoCulturaisEEsportivas);
                case CategoriaAtividadeComplementarEnum.ParticipacaoOrganizacaoEventos:
                    return (usuario.HorasTotaisDeParticipacaoOuOrganizacaoDeEventos,
                        usuario.horasRestantesDeParticipacaoOuOrganizacaoDeEventos);
                case CategoriaAtividadeComplementarEnum.ExperienciasProfissionais:
                    return (usuario.HorasTotaisDeExperienciasLigadasAFormacaoProfissional,
                        usuario.horasRestantesDeExperienciasLigadasAFormacaoProfissional);
                case CategoriaAtividadeComplementarEnum.ProducaoTecnicaCientifica:
                    return (usuario.HorasTotaisDeProducaoTecnicaOuCientifica,
                        usuario.horasRestantesDeProducaoTecnicaOuCientifica);
                case CategoriaAtividadeComplementarEnum.VivenciasDeGestao:
                    return (usuario.HorasTotaisDeVivenciasDeGestao, usuario.horasRestantesDeVivenciasDeGestao);
                case CategoriaAtividadeComplementarEnum.OutrasAtividades:
                    return (usuario.HorasTotaisDeOutrasAtividades, usuario.horasRestantesDeOutrasAtividades);
                default:
                    return (0, 0);
            }
        }

        return (0, 0);
    }

    public void AddAsync(ReqAtividadeUsuarioDTO dto, int matricula, IFormFile comprovante)
    {
        AtividadeFactory atividadeFactory = new ConcreteAtividadeFactory(
            _usuarioRepository,
            _comprovanteService,
            _atividadeUsuarioRepositoryRepository
        );
        atividadeFactory.CriarAtividade(dto, matricula, comprovante);
    }

    public void IntegralizarHoras(Guid atividadeId)
    {
        IntegralizacaoHorasFactory horasFactory = new ConcreteHorasFactory(_usuarioRepository, _atividadesRepository);
        horasFactory.alocarHoras(atividadeId);
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
        atividade.qtdHorasUtilizadas =
            dto.qtdHorasUtilizadas != 0 ? dto.qtdHorasUtilizadas : atividade.qtdHorasUtilizadas;

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

public record ResHoraDetailsDTO
{
    public string NomeCategoria { get; set; }
    public int HorasTotaisDaCategoria { get; set; }
    public int HorasSubmetidas { get; set; }
    public int HorasPendentes { get; set; }
    public int HorasTotaisCurso { get; set; }
    public int horasRestantesTotaisCurso { get; set; }

    public ResHoraDetailsDTO(string nomeCategoria, int horasTotais, int horasUtilizadas, int horasRestantes,int horasTotaisCurso, int horasRestantesTotaisCurso)
    {
        NomeCategoria = nomeCategoria;
        HorasTotaisDaCategoria = horasTotais;
        HorasSubmetidas = horasUtilizadas;
        HorasPendentes = horasRestantes;
        HorasTotaisCurso =  horasTotaisCurso;
        this.horasRestantesTotaisCurso = horasRestantesTotaisCurso;
    }
}