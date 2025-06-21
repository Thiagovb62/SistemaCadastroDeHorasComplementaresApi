namespace SistemaCadastroDeHorasApi.Models.DTO;



public record ResAtividadeUsario(
    Guid Id,
    Usuario usuario,
    Atividades atividade,
    string nomeArquivo,
    string tipoArquivo
);