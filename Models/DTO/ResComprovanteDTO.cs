namespace SistemaCadastroDeHorasApi.Models.DTO;
public record ResComprovanteDTO(
    byte[] arquivo,
    string nomeArquivo,
    string tipoArquivo
);