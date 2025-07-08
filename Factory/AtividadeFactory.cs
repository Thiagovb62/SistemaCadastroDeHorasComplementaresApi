using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.Builders;
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

    public  Atividades CriarAtividade(ReqAtividadeUsuarioDTO dto, int matricula)

    {
        var atividade = new Atividades();
        var usuario = _usuarioRepository.GetByMatriculaAsync(matricula).Result;
        switch (dto.TipoAtividadeId)
        {
            case 1:
                 new AtividadeBuilder()
                    .ForUsuario(usuario.Id)
                    .WithDatas(dto.DataInicio, dto.DataFim)
                    .WithTipoInfo(dto.TipoAtividadeId, dto.TipoParticipacaoId)
                    .WithLocalizacao(dto.pais, dto.cnpj)
                    .WithDetalhes(dto.titulo, dto.nomeInstituicao, dto.isExecUfc)
                    .WithCargaHoraria(dto.cargaHoraria, dto.qtdHorasUtilizadas)
                    .WithComprovante(dto.comprovante)
                    .WithAtividadeComplementar(TipoAtividadeComplementarHorasEnum.ParticipacaoOrganizacaoEventos)
                    .Build();
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
            case 2:
                // atividade = new Atividades
                // {
                //     Id = Guid.NewGuid(),
                //     TipoAtividadeId = dto.TipoAtividadeId,
                //     UsuarioId = usuario.Id ,
                //     TipoParticipacaoId = dto.TipoParticipacaoId,
                //     pais = dto.pais,
                //     titulo = dto.titulo,
                //     cargaHoraria = dto.cargaHoraria,
                //     dataInicio = dto.DataInicio,
                //     dataFim = dto.DataFim,
                //     nomeInstituicao = dto.nomeInstituicao,
                //     isExecUfc = dto.isExecUfc,
                //     qtdHorasUtilizadas = dto.qtdHorasUtilizadas,
                //     cnpj = dto.cnpj,
                //     tipoAtividadeComplementarHoras = TipoAtividadeComplementarHorasEnum.ParticipacaoOrganizacaoEventos
                // };
                // atividade.comprovante = arquivo;
                // atividade.nomeArquivo = nomeArquivo;
                // atividade.tipoArquivo = tipoArquivo;
                atividade = new AtividadeBuilder()
                    .ForUsuario(usuario.Id)
                    .WithDatas(dto.DataInicio, dto.DataFim)
                    .WithTipoInfo(dto.TipoAtividadeId, dto.TipoParticipacaoId)
                    .WithLocalizacao(dto.pais, dto.cnpj)
                    .WithDetalhes(dto.titulo, dto.nomeInstituicao, dto.isExecUfc)
                    .WithCargaHoraria(dto.cargaHoraria, dto.qtdHorasUtilizadas)
                    .WithComprovante(dto.comprovante)
                    .WithAtividadeComplementar(TipoAtividadeComplementarHorasEnum.ParticipacaoOrganizacaoEventos)
                    .Build();
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
            case 3:
                atividade = new AtividadeBuilder()
                    .ForUsuario(usuario.Id)
                    .WithDatas(dto.DataInicio, dto.DataFim)
                    .WithTipoInfo(dto.TipoAtividadeId, dto.TipoParticipacaoId)
                    .WithLocalizacao(dto.pais, dto.cnpj)
                    .WithDetalhes(dto.titulo, dto.nomeInstituicao, dto.isExecUfc)
                    .WithCargaHoraria(dto.cargaHoraria, dto.qtdHorasUtilizadas)
                    .WithComprovante(dto.comprovante)
                    .WithAtividadeComplementar(TipoAtividadeComplementarHorasEnum.ParticipacaoOrganizacaoEventos)
                    .Build();
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
            case 4:
                atividade = new AtividadeBuilder()
                    .ForUsuario(usuario.Id)
                    .WithDatas(dto.DataInicio, dto.DataFim)
                    .WithTipoInfo(dto.TipoAtividadeId, dto.TipoParticipacaoId)
                    .WithLocalizacao(dto.pais, dto.cnpj)
                    .WithDetalhes(dto.titulo, dto.nomeInstituicao, dto.isExecUfc)
                    .WithCargaHoraria(dto.cargaHoraria, dto.qtdHorasUtilizadas)
                    .WithComprovante(dto.comprovante)
                    .WithAtividadeComplementar(TipoAtividadeComplementarHorasEnum.ParticipacaoOrganizacaoEventos)
                    .Build();
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
            case 5:
                atividade = new AtividadeBuilder()
                    .ForUsuario(usuario.Id)
                    .WithDatas(dto.DataInicio, dto.DataFim)
                    .WithTipoInfo(dto.TipoAtividadeId, dto.TipoParticipacaoId)
                    .WithLocalizacao(dto.pais, dto.cnpj)
                    .WithDetalhes(dto.titulo, dto.nomeInstituicao, dto.isExecUfc)
                    .WithCargaHoraria(dto.cargaHoraria, dto.qtdHorasUtilizadas)
                    .WithComprovante(dto.comprovante)
                    .WithAtividadeComplementar(TipoAtividadeComplementarHorasEnum.ExperienciasProfissionais)
                    .Build();
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
            case 6:
                atividade = new AtividadeBuilder()
                    .ForUsuario(usuario.Id)
                    .WithDatas(dto.DataInicio, dto.DataFim)
                    .WithTipoInfo(dto.TipoAtividadeId, dto.TipoParticipacaoId)
                    .WithLocalizacao(dto.pais, dto.cnpj)
                    .WithDetalhes(dto.titulo, dto.nomeInstituicao, dto.isExecUfc)
                    .WithCargaHoraria(dto.cargaHoraria, dto.qtdHorasUtilizadas)
                    .WithComprovante(dto.comprovante)
                    .WithAtividadeComplementar(TipoAtividadeComplementarHorasEnum.IniciacaoDocenciaPesquisaExtensao)
                    .Build();
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break; 
            case 7:
                atividade = new AtividadeBuilder()
                    .ForUsuario(usuario.Id)
                    .WithDatas(dto.DataInicio, dto.DataFim)
                    .WithTipoInfo(dto.TipoAtividadeId, dto.TipoParticipacaoId)
                    .WithLocalizacao(dto.pais, dto.cnpj)
                    .WithDetalhes(dto.titulo, dto.nomeInstituicao, dto.isExecUfc)
                    .WithCargaHoraria(dto.cargaHoraria, dto.qtdHorasUtilizadas)
                    .WithComprovante(dto.comprovante)
                    .WithAtividadeComplementar(TipoAtividadeComplementarHorasEnum.IniciacaoDocenciaPesquisaExtensao)
                    .Build();
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
            case 8:
                atividade = new AtividadeBuilder()
                    .ForUsuario(usuario.Id)
                    .WithDatas(dto.DataInicio, dto.DataFim)
                    .WithTipoInfo(dto.TipoAtividadeId, dto.TipoParticipacaoId)
                    .WithLocalizacao(dto.pais, dto.cnpj)
                    .WithDetalhes(dto.titulo, dto.nomeInstituicao, dto.isExecUfc)
                    .WithCargaHoraria(dto.cargaHoraria, dto.qtdHorasUtilizadas)
                    .WithComprovante(dto.comprovante)
                    .WithAtividadeComplementar(TipoAtividadeComplementarHorasEnum.OutrasAtividades)
                    .Build();
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
             case 9:
                atividade = new AtividadeBuilder()
                    .ForUsuario(usuario.Id)
                    .WithDatas(dto.DataInicio, dto.DataFim)
                    .WithTipoInfo(dto.TipoAtividadeId, dto.TipoParticipacaoId)
                    .WithLocalizacao(dto.pais, dto.cnpj)
                    .WithDetalhes(dto.titulo, dto.nomeInstituicao, dto.isExecUfc)
                    .WithCargaHoraria(dto.cargaHoraria, dto.qtdHorasUtilizadas)
                    .WithComprovante(dto.comprovante)
                    .WithAtividadeComplementar(TipoAtividadeComplementarHorasEnum.IniciacaoDocenciaPesquisaExtensao)
                    .Build();
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
              case 10:
                atividade = new AtividadeBuilder()
                    .ForUsuario(usuario.Id)
                    .WithDatas(dto.DataInicio, dto.DataFim)
                    .WithTipoInfo(dto.TipoAtividadeId, dto.TipoParticipacaoId)
                    .WithLocalizacao(dto.pais, dto.cnpj)
                    .WithDetalhes(dto.titulo, dto.nomeInstituicao, dto.isExecUfc)
                    .WithCargaHoraria(dto.cargaHoraria, dto.qtdHorasUtilizadas)
                    .WithComprovante(dto.comprovante)
                    .WithAtividadeComplementar(TipoAtividadeComplementarHorasEnum.ProducaoTecnicaCientifica)
                    .Build();
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
             case 11:
                atividade = new AtividadeBuilder()
                    .ForUsuario(usuario.Id)
                    .WithDatas(dto.DataInicio, dto.DataFim)
                    .WithTipoInfo(dto.TipoAtividadeId, dto.TipoParticipacaoId)
                    .WithLocalizacao(dto.pais, dto.cnpj)
                    .WithDetalhes(dto.titulo, dto.nomeInstituicao, dto.isExecUfc)
                    .WithCargaHoraria(dto.cargaHoraria, dto.qtdHorasUtilizadas)
                    .WithComprovante(dto.comprovante)
                    .WithAtividadeComplementar(TipoAtividadeComplementarHorasEnum.IniciacaoDocenciaPesquisaExtensao)
                    .Build();
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
              case 12:
                atividade = new AtividadeBuilder()
                    .ForUsuario(usuario.Id)
                    .WithDatas(dto.DataInicio, dto.DataFim)
                    .WithTipoInfo(dto.TipoAtividadeId, dto.TipoParticipacaoId)
                    .WithLocalizacao(dto.pais, dto.cnpj)
                    .WithDetalhes(dto.titulo, dto.nomeInstituicao, dto.isExecUfc)
                    .WithCargaHoraria(dto.cargaHoraria, dto.qtdHorasUtilizadas)
                    .WithComprovante(dto.comprovante)
                    .WithAtividadeComplementar(TipoAtividadeComplementarHorasEnum.IniciacaoDocenciaPesquisaExtensao)
                    .Build();
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
              case 13:
                atividade = new AtividadeBuilder()
                    .ForUsuario(usuario.Id)
                    .WithDatas(dto.DataInicio, dto.DataFim)
                    .WithTipoInfo(dto.TipoAtividadeId, dto.TipoParticipacaoId)
                    .WithLocalizacao(dto.pais, dto.cnpj)
                    .WithDetalhes(dto.titulo, dto.nomeInstituicao, dto.isExecUfc)
                    .WithCargaHoraria(dto.cargaHoraria, dto.qtdHorasUtilizadas)
                    .WithComprovante(dto.comprovante)
                    .WithAtividadeComplementar(TipoAtividadeComplementarHorasEnum.VivenciasDeGestao)
                    .Build();
                _atividadeUsuarioRepositoryRepository.AddAsync(atividade, matricula);
                break;
        }

        return atividade;
    }
}