using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;

namespace SistemaCadastroDeHorasApi.Services.Contracts;

public interface IAtividadeUsuarioService
{
    Task<IEnumerable<ResAtividadeUsario>> GetAllAsync();
    Task<IEnumerable<ResAtividadeUsario>> GetByUserIdAsync(int id);
    Task AddAsync(Atividades atividade, int usuarioId);
    Task DeleteAsync(int id);
}