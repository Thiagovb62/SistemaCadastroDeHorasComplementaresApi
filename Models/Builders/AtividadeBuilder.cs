using SistemaCadastroDeHorasApi.Models.ENUMS;

namespace SistemaCadastroDeHorasApi.Models.Builders;

public class AtividadeBuilder : IAtividadeBuilder
{
    private readonly Atividades _atividade;

    public AtividadeBuilder()
    {
        _atividade = new Atividades();
    }

    public IAtividadeBuilder WithDatas(DateTime inicio, DateTime fim)
    {
        _atividade.dataInicio = inicio;
        _atividade.dataFim = fim;
        return this;
    }

    public IAtividadeBuilder WithTipoInfo(int tipoAtividadeId, int tipoParticipacaoId)
    {
        _atividade.TipoAtividadeId = tipoAtividadeId;
        _atividade.TipoParticipacaoId = tipoParticipacaoId;
        return this;
    }

    public IAtividadeBuilder WithLocalizacao(string pais, string? cnpj = null)
    {
        _atividade.pais = pais;
        _atividade.cnpj = cnpj;
        return this;
    }

    public IAtividadeBuilder WithDetalhes(string titulo, string nomeInstituicao, bool isExecUfc)
    {
        _atividade.titulo = titulo;
        _atividade.nomeInstituicao = nomeInstituicao;
        _atividade.isExecUfc = isExecUfc;
        return this;
    }

    public IAtividadeBuilder WithCargaHoraria(int cargaHoraria, int horasUtilizadas)
    {
        _atividade.cargaHoraria = cargaHoraria;
        _atividade.qtdHorasUtilizadas = horasUtilizadas;
        return this;
    }

    public IAtividadeBuilder WithComprovante(IFormFile comprovante)
    {
        using (var memoryStream = new MemoryStream())
        {
            comprovante.CopyTo(memoryStream);
            _atividade.comprovante = memoryStream.ToArray();
            _atividade.nomeArquivo = comprovante.FileName;
            _atividade.tipoArquivo = comprovante.ContentType;
        }
        return this;
    }
    
    public IAtividadeBuilder WithAtividadeComplementar(TipoAtividadeComplementarHorasEnum tipoAtividadeComplementar)
    {
        _atividade.tipoAtividadeComplementarHoras = tipoAtividadeComplementar;
        return this;
    }

    public IAtividadeBuilder ForUsuario(int usuarioId)
    {
        _atividade.UsuarioId = usuarioId;
        return this;
    }

    public Atividades Build()
    {
        return _atividade;
    }
    
}