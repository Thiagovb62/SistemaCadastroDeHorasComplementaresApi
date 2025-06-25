namespace SistemaCadastroDeHorasApi.Models.DTO;



public record ResAtividadeUsario(
    ResUserDTO Usuario,
    ResAtividadeDTO Atividade,
    string nomeArquivo,
    string tipoArquivo
);