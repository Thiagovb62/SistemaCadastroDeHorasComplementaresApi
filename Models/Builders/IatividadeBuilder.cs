using SistemaCadastroDeHorasApi.Models.ENUMS;

namespace SistemaCadastroDeHorasApi.Models.Builders;

public interface IAtividadeBuilder
{
        IAtividadeBuilder WithDatas(DateTime inicio, DateTime fim);
        IAtividadeBuilder WithTipoInfo(int tipoAtividadeId, int tipoParticipacaoId);
        IAtividadeBuilder WithLocalizacao(string pais, string? cnpj = null);
        IAtividadeBuilder WithDetalhes(string titulo, string nomeInstituicao, bool isExecUfc);
        IAtividadeBuilder WithCargaHoraria(int cargaHoraria, int horasUtilizadas);
        IAtividadeBuilder WithComprovante(IFormFile comprovante);
        IAtividadeBuilder WithAtividadeComplementar(TipoAtividadeComplementarHorasEnum tipoAtividadeComplementar);
        IAtividadeBuilder ForUsuario(int usuarioId);
        Atividades Build();
    
}