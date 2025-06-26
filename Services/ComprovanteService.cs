using SistemaCadastroDeHorasApi.Repositories;

namespace SistemaCadastroDeHorasApi.Services;

public class ComprovanteService : IComprovanteService
{
    private readonly IAtividadesRepository _atividadesRepository;

    public ComprovanteService  (IAtividadesRepository atividadesRepository)
    {
        _atividadesRepository = atividadesRepository;
    }

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

    public async Task<byte[]> GetComprovante(Guid atividadeId)
    {
        var comprovanteAtividade = await _atividadesRepository.GetComprovanteAsync(atividadeId);

        return comprovanteAtividade.arquivo;
    }
}