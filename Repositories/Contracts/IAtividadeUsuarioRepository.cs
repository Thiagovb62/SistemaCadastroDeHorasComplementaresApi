using SistemaCadastroDeHorasApi.Models;

namespace SistemaCadastroDeHorasApi.Repositories.Contracts;

public interface IAtividadeUsuarioRepository
{
    
    Task<IEnumerable<AtividadeUsuario>> GetByUsuarioIdAsync(int usuarioId);
    Task AddAsync(Atividades atividades, int usuarioId);
    Task UpdateAsync(AtividadeUsuario atividadeUsuario);
    Task DeleteAsync(int id);
}