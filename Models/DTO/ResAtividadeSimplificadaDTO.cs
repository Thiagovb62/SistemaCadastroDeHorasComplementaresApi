namespace SistemaCadastroDeHorasApi.Models.DTO;
public record ResAtividadeSimplificadaDTO(
    Guid id,
    DateTime submissionDate,
    string type,
    string title,
    int hours,
    string status
);

