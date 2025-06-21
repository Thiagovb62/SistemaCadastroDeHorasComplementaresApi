using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;

namespace SistemaCadastroDeHorasApi.Services.Contracts;

public interface IAtividadeUsuarioService
{
    Task<IEnumerable<ResAtividadeUsario>> GetAllAsync();
    Task<IEnumerable<ResAtividadeUsario>> GetAllByUserIdAsync(int id);
    Task AddAsync(Atividades atividade, int usuarioId, IFormFile comprovante);
    Task DeleteAsync(int id);
}