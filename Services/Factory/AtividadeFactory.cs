using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;
using SistemaCadastroDeHorasApi.Models.ENUMS;
using SistemaCadastroDeHorasApi.Repositories;
using SistemaCadastroDeHorasApi.Repositories.Contracts;

namespace SistemaCadastroDeHorasApi.Services.Factory;

public abstract class AtividadeFactory
{
    
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IComprovanteService _comprovanteService;
    private readonly IAtividadeUsuarioRepository _atividadeUsuarioRepositoryRepository;

    public AtividadeFactory( IUsuarioRepository usuarioRepository,
        IComprovanteService comprovanteAuxiliary,
        IAtividadeUsuarioRepository atividadeUsuarioRepositoryRepository)
    {
    
        _usuarioRepository = usuarioRepository;
        _comprovanteService = comprovanteAuxiliary;
        _atividadeUsuarioRepositoryRepository = atividadeUsuarioRepositoryRepository;
    }

    public  Atividades CriarAtividade(ReqAtividadeUsuarioDTO dto, int matricula, IFormFile comprovante)

    {
        var atividade = new Atividades();
        var (arquivo, nomeArquivo, tipoArquivo) = _comprovanteService.ConvertComprovante(comprovante);
        var usuario = _usuarioRepository.GetByMatriculaAsync(matricula).Result;
        switch (dto.TipoAtividadeId)
        {
            case 1:
                 atividade = new Atividades
                {
                    Id = Guid.NewGuid(),
                    TipoAtividadeId = dto.TipoAtividadeId,
                    UsuarioId = usuario.Id ,
                    TipoParticipacaoId = dto.TipoParticipacaoId,
                    pais = dto.pais,
                    titulo = dto.titulo,
                    cargaHoraria = dto.cargaHoraria,
                    dataInicio = dto.DataInicio,
                    dataFim = dto.DataFim,
                    nomeInstituicao = dto.nomeInstituicao,
                    isExecUfc = dto.isExecUfc,
                    qtdHorasUtilizadas = dto.qtdHorasUtilizadas,
                    cnpj = dto.cnpj,
                    categoriaAtividadeComplementarHoras = CategoriaAtividadeComplementarEnum.AtividadesArtisticoCulturaisEsportivas
                };
                atividade.comprovante = arquivo;
                atividade.nomeArquivo = nomeArquivo;
                atividade.tipoArquivo = tipoArquivo;
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
            case 2:
                atividade = new Atividades
                {
                    Id = Guid.NewGuid(),
                    TipoAtividadeId = dto.TipoAtividadeId,
                    UsuarioId = usuario.Id ,
                    TipoParticipacaoId = dto.TipoParticipacaoId,
                    pais = dto.pais,
                    titulo = dto.titulo,
                    cargaHoraria = dto.cargaHoraria,
                    dataInicio = dto.DataInicio,
                    dataFim = dto.DataFim,
                    nomeInstituicao = dto.nomeInstituicao,
                    isExecUfc = dto.isExecUfc,
                    qtdHorasUtilizadas = dto.qtdHorasUtilizadas,
                    cnpj = dto.cnpj,
                    categoriaAtividadeComplementarHoras = CategoriaAtividadeComplementarEnum.ParticipacaoOrganizacaoEventos
                };
                atividade.comprovante = arquivo;
                atividade.nomeArquivo = nomeArquivo;
                atividade.tipoArquivo = tipoArquivo;
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
            case 3:
                atividade = new Atividades
                {
                    Id = Guid.NewGuid(),
                    TipoAtividadeId = dto.TipoAtividadeId,
                    UsuarioId = usuario.Id ,
                    TipoParticipacaoId = dto.TipoParticipacaoId,
                    pais = dto.pais,
                    titulo = dto.titulo,
                    cargaHoraria = dto.cargaHoraria,
                    dataInicio = dto.DataInicio,
                    dataFim = dto.DataFim,
                    nomeInstituicao = dto.nomeInstituicao,
                    isExecUfc = dto.isExecUfc,
                    qtdHorasUtilizadas = dto.qtdHorasUtilizadas,
                    cnpj = dto.cnpj,
                    categoriaAtividadeComplementarHoras = CategoriaAtividadeComplementarEnum.ParticipacaoOrganizacaoEventos
                };
                atividade.comprovante = arquivo;
                atividade.nomeArquivo = nomeArquivo;
                atividade.tipoArquivo = tipoArquivo;
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
            case 4:
                atividade = new Atividades
                {
                    Id = Guid.NewGuid(),
                    TipoAtividadeId = dto.TipoAtividadeId,
                    UsuarioId = usuario.Id ,
                    TipoParticipacaoId = dto.TipoParticipacaoId,
                    pais = dto.pais,
                    titulo = dto.titulo,
                    cargaHoraria = dto.cargaHoraria,
                    dataInicio = dto.DataInicio,
                    dataFim = dto.DataFim,
                    nomeInstituicao = dto.nomeInstituicao,
                    isExecUfc = dto.isExecUfc,
                    qtdHorasUtilizadas = dto.qtdHorasUtilizadas,
                    cnpj = dto.cnpj,
                    categoriaAtividadeComplementarHoras = CategoriaAtividadeComplementarEnum.ParticipacaoOrganizacaoEventos
                };
                atividade.comprovante = arquivo;
                atividade.nomeArquivo = nomeArquivo;
                atividade.tipoArquivo = tipoArquivo;
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
            case 5:
                atividade = new Atividades
                {
                    Id = Guid.NewGuid(),
                    TipoAtividadeId = dto.TipoAtividadeId,
                    UsuarioId = usuario.Id ,
                    TipoParticipacaoId = dto.TipoParticipacaoId,
                    pais = dto.pais,
                    titulo = dto.titulo,
                    cargaHoraria = dto.cargaHoraria,
                    dataInicio = dto.DataInicio,
                    dataFim = dto.DataFim,
                    nomeInstituicao = dto.nomeInstituicao,
                    isExecUfc = dto.isExecUfc,
                    qtdHorasUtilizadas = dto.qtdHorasUtilizadas,
                    cnpj = dto.cnpj,
                    categoriaAtividadeComplementarHoras = CategoriaAtividadeComplementarEnum.ExperienciasProfissionais
                };
                atividade.comprovante = arquivo;
                atividade.nomeArquivo = nomeArquivo;
                atividade.tipoArquivo = tipoArquivo;
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
            case 6:
                atividade = new Atividades
                {
                    Id = Guid.NewGuid(),
                    TipoAtividadeId = dto.TipoAtividadeId,
                    UsuarioId = usuario.Id ,
                    TipoParticipacaoId = dto.TipoParticipacaoId,
                    pais = dto.pais,
                    titulo = dto.titulo,
                    cargaHoraria = dto.cargaHoraria,
                    dataInicio = dto.DataInicio,
                    dataFim = dto.DataFim,
                    nomeInstituicao = dto.nomeInstituicao,
                    isExecUfc = dto.isExecUfc,
                    qtdHorasUtilizadas = dto.qtdHorasUtilizadas,
                    cnpj = dto.cnpj,
                    categoriaAtividadeComplementarHoras = CategoriaAtividadeComplementarEnum.IniciacaoDocenciaPesquisaExtensao
                };
                atividade.comprovante = arquivo;
                atividade.nomeArquivo = nomeArquivo;
                atividade.tipoArquivo = tipoArquivo;
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break; 
            case 7:
                atividade = new Atividades
                {
                    Id = Guid.NewGuid(),
                    TipoAtividadeId = dto.TipoAtividadeId,
                    UsuarioId = usuario.Id ,
                    TipoParticipacaoId = dto.TipoParticipacaoId,
                    pais = dto.pais,
                    titulo = dto.titulo,
                    cargaHoraria = dto.cargaHoraria,
                    dataInicio = dto.DataInicio,
                    dataFim = dto.DataFim,
                    nomeInstituicao = dto.nomeInstituicao,
                    isExecUfc = dto.isExecUfc,
                    qtdHorasUtilizadas = dto.qtdHorasUtilizadas,
                    cnpj = dto.cnpj,
                    categoriaAtividadeComplementarHoras = CategoriaAtividadeComplementarEnum.IniciacaoDocenciaPesquisaExtensao
                };
                atividade.comprovante = arquivo;
                atividade.nomeArquivo = nomeArquivo;
                atividade.tipoArquivo = tipoArquivo;
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
            case 8:
                atividade = new Atividades
                {
                    Id = Guid.NewGuid(),
                    TipoAtividadeId = dto.TipoAtividadeId,
                    UsuarioId = usuario.Id ,
                    TipoParticipacaoId = dto.TipoParticipacaoId,
                    pais = dto.pais,
                    titulo = dto.titulo,
                    cargaHoraria = dto.cargaHoraria,
                    dataInicio = dto.DataInicio,
                    dataFim = dto.DataFim,
                    nomeInstituicao = dto.nomeInstituicao,
                    isExecUfc = dto.isExecUfc,
                    qtdHorasUtilizadas = dto.qtdHorasUtilizadas,
                    cnpj = dto.cnpj,
                    categoriaAtividadeComplementarHoras = CategoriaAtividadeComplementarEnum.OutrasAtividades
                };
                atividade.comprovante = arquivo;
                atividade.nomeArquivo = nomeArquivo;
                atividade.tipoArquivo = tipoArquivo;
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
             case 9:
                atividade = new Atividades
                {
                    Id = Guid.NewGuid(),
                    TipoAtividadeId = dto.TipoAtividadeId,
                    UsuarioId = usuario.Id ,
                    TipoParticipacaoId = dto.TipoParticipacaoId,
                    pais = dto.pais,
                    titulo = dto.titulo,
                    cargaHoraria = dto.cargaHoraria,
                    dataInicio = dto.DataInicio,
                    dataFim = dto.DataFim,
                    nomeInstituicao = dto.nomeInstituicao,
                    isExecUfc = dto.isExecUfc,
                    qtdHorasUtilizadas = dto.qtdHorasUtilizadas,
                    cnpj = dto.cnpj,
                    categoriaAtividadeComplementarHoras = CategoriaAtividadeComplementarEnum.IniciacaoDocenciaPesquisaExtensao
                };
                atividade.comprovante = arquivo;
                atividade.nomeArquivo = nomeArquivo;
                atividade.tipoArquivo = tipoArquivo;
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
              case 10:
                atividade = new Atividades
                {
                    Id = Guid.NewGuid(),
                    TipoAtividadeId = dto.TipoAtividadeId,
                    UsuarioId = usuario.Id ,
                    TipoParticipacaoId = dto.TipoParticipacaoId,
                    pais = dto.pais,
                    titulo = dto.titulo,
                    cargaHoraria = dto.cargaHoraria,
                    dataInicio = dto.DataInicio,
                    dataFim = dto.DataFim,
                    nomeInstituicao = dto.nomeInstituicao,
                    isExecUfc = dto.isExecUfc,
                    qtdHorasUtilizadas = dto.qtdHorasUtilizadas,
                    cnpj = dto.cnpj,
                    categoriaAtividadeComplementarHoras = CategoriaAtividadeComplementarEnum.ProducaoTecnicaCientifica
                };
                atividade.comprovante = arquivo;
                atividade.nomeArquivo = nomeArquivo;
                atividade.tipoArquivo = tipoArquivo;
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
             case 11:
                atividade = new Atividades
                {
                    Id = Guid.NewGuid(),
                    TipoAtividadeId = dto.TipoAtividadeId,
                    UsuarioId = usuario.Id ,
                    TipoParticipacaoId = dto.TipoParticipacaoId,
                    pais = dto.pais,
                    titulo = dto.titulo,
                    cargaHoraria = dto.cargaHoraria,
                    dataInicio = dto.DataInicio,
                    dataFim = dto.DataFim,
                    nomeInstituicao = dto.nomeInstituicao,
                    isExecUfc = dto.isExecUfc,
                    qtdHorasUtilizadas = dto.qtdHorasUtilizadas,
                    cnpj = dto.cnpj,
                    categoriaAtividadeComplementarHoras = CategoriaAtividadeComplementarEnum.IniciacaoDocenciaPesquisaExtensao
                };
                atividade.comprovante = arquivo;
                atividade.nomeArquivo = nomeArquivo;
                atividade.tipoArquivo = tipoArquivo;
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
              case 12:
                atividade = new Atividades
                {
                    Id = Guid.NewGuid(),
                    TipoAtividadeId = dto.TipoAtividadeId,
                    UsuarioId = usuario.Id ,
                    TipoParticipacaoId = dto.TipoParticipacaoId,
                    pais = dto.pais,
                    titulo = dto.titulo,
                    cargaHoraria = dto.cargaHoraria,
                    dataInicio = dto.DataInicio,
                    dataFim = dto.DataFim,
                    nomeInstituicao = dto.nomeInstituicao,
                    isExecUfc = dto.isExecUfc,
                    qtdHorasUtilizadas = dto.qtdHorasUtilizadas,
                    cnpj = dto.cnpj,
                    categoriaAtividadeComplementarHoras = CategoriaAtividadeComplementarEnum.IniciacaoDocenciaPesquisaExtensao
                };
                atividade.comprovante = arquivo;
                atividade.nomeArquivo = nomeArquivo;
                atividade.tipoArquivo = tipoArquivo;
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
              case 13:
                atividade = new Atividades
                {
                    Id = Guid.NewGuid(),
                    TipoAtividadeId = dto.TipoAtividadeId,
                    UsuarioId = usuario.Id ,
                    TipoParticipacaoId = dto.TipoParticipacaoId,
                    pais = dto.pais,
                    titulo = dto.titulo,
                    cargaHoraria = dto.cargaHoraria,
                    dataInicio = dto.DataInicio,
                    dataFim = dto.DataFim,
                    nomeInstituicao = dto.nomeInstituicao,
                    isExecUfc = dto.isExecUfc,
                    qtdHorasUtilizadas = dto.qtdHorasUtilizadas,
                    cnpj = dto.cnpj,
                    categoriaAtividadeComplementarHoras = CategoriaAtividadeComplementarEnum.VivenciasDeGestao
                };
                atividade.comprovante = arquivo;
                atividade.nomeArquivo = nomeArquivo;
                atividade.tipoArquivo = tipoArquivo;
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
        }

        return atividade;
    }
}