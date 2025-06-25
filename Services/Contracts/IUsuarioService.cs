using SistemaCadastroDeHorasApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaCadastroDeHorasApi.Models.DTO;

namespace SistemaCadastroDeHorasApi.Services;

public interface IUsuarioService
{
    Task<IEnumerable<Usuario>> GetAllAsync();
    Task<Usuario> GetByMatriculaAsync(int matricula);
    Task<Usuario> CreateAsync(ReqUserDTO usuario);
    Task<Usuario> UpdateAsync(int id, ReqUpdateUserDTO usuario);
    Task<bool> DeleteAsync(int matricula);
}
