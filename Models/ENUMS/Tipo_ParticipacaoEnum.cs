namespace SistemaCadastroDeHorasApi.Models.ENUMS;
public enum Tipo_ParticipacaoEnum
{
    MEMBRO_DA_EQUIPE_DE_TRABALHO,
    PUBLICO_ATENDIDO_OU_ESPECTADOR,
}
public static class Tipo_ParticipacaoEnumExtensions
{
    public static Tipo_ParticipacaoEnum? FromString(string value)
    {
        if (Enum.TryParse<Tipo_ParticipacaoEnum>(value, true, out var result))
        {
            return result;
        }
        return null;
    }
}
