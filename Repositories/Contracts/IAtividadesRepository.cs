using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaCadastroDeHorasApi.Repositories;

public interface IAtividadesRepository
{

    Task<IEnumerable<Atividades>> GetByUserIdAsync(int id);
    Task DeleteAsync(Guid id);
    Task<ResComprovanteDTO> GetComprovanteAsync(Guid id);
}
