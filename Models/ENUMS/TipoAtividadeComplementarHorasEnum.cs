using System.ComponentModel;
using System.Reflection;

namespace SistemaCadastroDeHorasApi.Models.ENUMS;

public enum TipoAtividadeComplementarHorasEnum
{
    [Description("Iniciação a Docência, Pesquisa e/ou Extensão")]
    IniciacaoDocenciaPesquisaExtensao,

    [Description("Participação e/ou Organização de Eventos")]
    ParticipacaoOrganizacaoEventos,

    [Description("Atividades Artístico-Culturais e Esportivas")]
    AtividadesArtisticoCulturaisEsportivas,

    [Description("Experiências Ligadas à Formação Profissional")]
    ExperienciasProfissionais,

    [Description("Produção Técnica e/ou Científica")]
    ProducaoTecnicaCientifica,

    [Description("Vivências de Gestão")] VivenciasDeGestao,

    [Description("Outras Atividades")] OutrasAtividades
}

public static class TipoAtividadeComplementarHorasEnumExtensions
{
    public static TipoAtividadeComplementarHorasEnum? FromString(string value)
    {
        if (Enum.TryParse<TipoAtividadeComplementarHorasEnum>(value, true, out var result))
        {
            return result;
        }

        return null;
    }

    public static string GetDescription(this Enum value)
    {
        FieldInfo? fieldInfo = value.GetType().GetField(value.ToString());
        if (fieldInfo == null) return value.ToString();

        var attributes = (DescriptionAttribute[]?)fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attributes is { Length: > 0 } ? attributes[0].Description : value.ToString();
    }

    public static TipoAtividadeComplementarHorasEnum? FromCode(int code)
    {
        if (Enum.IsDefined(typeof(TipoAtividadeComplementarHorasEnum), code))
        {
            return FromString(Enum.GetName(typeof(TipoAtividadeComplementarHorasEnum), code) ?? string.Empty);
        }

        return null;
    }
}