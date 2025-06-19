using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;

namespace SistemaCadastroDeHorasApi.Services;

public class ComprovanteService : IComprovanteService
{
    public (byte[] comprovante, string nomeArquivo, string tipoArquivo) ConvertComprovante(IFormFile comprovante)
    {
        if (comprovante == null || comprovante.Length > 5 * 1024 * 1024)
        {
            throw new ArgumentException("Comprovante de no máximo 5MB é obrigatório.");
        }

        if (!comprovante.ContentType.Equals("application/pdf", StringComparison.OrdinalIgnoreCase))
        {
            throw new ArgumentException("Somente comprovantes em PDF são aceitos.");
        }

        using var memoryStream = new MemoryStream();
        comprovante.CopyTo(memoryStream);

        return (memoryStream.ToArray(), comprovante.FileName, comprovante.ContentType);
    }
}