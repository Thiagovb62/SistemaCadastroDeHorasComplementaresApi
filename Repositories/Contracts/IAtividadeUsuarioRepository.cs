using SistemaCadastroDeHorasApi.Models;

namespace SistemaCadastroDeHorasApi.Repositories.Contracts;

public interface IAtividadeUsuarioRepository
{
    Task<IEnumerable<AtividadeUsuario>> GetAllAsync();
    Task<AtividadeUsuario> GetByIdAsync(Guid id);
    Task<IEnumerable<AtividadeUsuario>> GetByUsuarioIdAsync(int usuarioId);
    Task<IEnumerable<AtividadeUsuario>> GetByStatusAsync(string status);
    Task AddAsync(Atividades atividades, int usuarioId);
    Task UpdateAsync(AtividadeUsuario atividadeUsuario);
    Task DeleteAsync(int id);
}