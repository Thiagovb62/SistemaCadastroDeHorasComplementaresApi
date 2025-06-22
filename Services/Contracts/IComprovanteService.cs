using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;

namespace SistemaCadastroDeHorasApi.Services;

public interface IComprovanteService
{
    (byte[] comprovante, string nomeArquivo, string tipoArquivo) ConvertComprovante(IFormFile comprovante);
}