namespace SistemaCadastroDeHorasApi.Models.ENUMS;

public enum Tipo_AtividadeEnum
{
    ATIVIDADE_ARTISTICO_CULTURAL_OU_ESPORTIVA,
    CURSO_DE_EXTENSAO_UNIVERSITARIA,
    EVENTO_DE_EXTENSAO_UNIVERSITARIA,
    EVENTOS_EXCETO_EXTENSAO_UNIVERSITARIA,
    EXPERIENCIA_DE_FORMACAO_PROFISSIONAL_OU_CORRELATAS,
    INICIACAO_A_DOCENCIA,
    INICIACAO_A_PESQUISA,
    OUTRAS_ATIVIDADES_ESTRATEGICAS_PARA_O_CURSO,
    PRESTACAO_DE_SERVICO_EM_EXTENSAO_UNIVERSITARIA,
    PRODUCAO_TECNICA_OU_CIENTIFICA,
    PROGRAMA_DE_EXTENSAO_UNIVERSITARIA,
    PROJETO_DE_EXTENSAO_UNIVERSITARIA,
    VIVENCIA_DE_GESTAO,
}
public static class Tipo_AtividadeEnumExtensions
{
    public static Tipo_AtividadeEnum? FromString(string value)
    {
        if (Enum.TryParse<Tipo_AtividadeEnum>(value, true, out var result))
        {
            return result;
        }
        return null; // Retorna null se não encontrar um valor correspondente
    }
}
