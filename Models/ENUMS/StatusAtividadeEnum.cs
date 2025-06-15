namespace SistemaCadastroDeHorasApi.Models.ENUMS;

public enum StatusAtividadeEnum
{   
    PENDENTE ,
    APROVADA 
}

public static class StatusAtividadeEnumExtensions
{
    public static StatusAtividadeEnum? FromString(string value)
    {
        if (Enum.TryParse<StatusAtividadeEnum>(value, true, out var result))
        {
            return result;
        }
        return null; // Retorna null se não encontrar um valor correspondente
    }
}