using SistemaCadastroDeHorasApi.Models;

namespace SistemaCadastroDeHorasApi.Repositories.Contracts;

public interface IAtividadeUsuarioRepository
{
    
    Task<IEnumerable<AtividadeUsuario>> GetAllByUserMatriculaAsync(int usuarioId);
    Task AddAsync(Atividades atividades, int usuarioId);
    Task UpdateAsync(AtividadeUsuario atividadeUsuario);
}