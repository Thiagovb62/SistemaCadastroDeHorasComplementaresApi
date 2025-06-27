namespace SistemaCadastroDeHorasApi.Services;

public interface IComprovanteService
{
    (byte[] comprovante, string nomeArquivo, string tipoArquivo) ConvertComprovante(IFormFile comprovante);
    Task<byte[]> GetComprovante(Guid atividadeId);
}