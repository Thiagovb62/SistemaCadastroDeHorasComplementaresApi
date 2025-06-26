using SistemaCadastroDeHorasApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaCadastroDeHorasApi.Repositories;

public interface IUsuarioRepository
{
    Task<IEnumerable<Usuario>> GetAllAsync();
    Task<Usuario> GetByIdAsync(int id);
    Task<Usuario> AddAsync(Usuario usuario);
    Task<Usuario> UpdateAsync(Usuario usuario);
    Task<bool> DeleteAsync(int id);
    Task<Usuario> GetByMatriculaAsync(int matricula);
    Task GetByMatriculaToCreateUserAsync(int matricula);
}
