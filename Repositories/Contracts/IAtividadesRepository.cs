using SistemaCadastroDeHorasApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaCadastroDeHorasApi.Repositories;

public interface IAtividadesRepository
{
    
    Task<IEnumerable<Atividades>> GetByUserIdAsync(int id);
    Task DeleteAsync(Guid id);
}
