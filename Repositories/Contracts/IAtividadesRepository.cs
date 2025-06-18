using SistemaCadastroDeHorasApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaCadastroDeHorasApi.Repositories;

public interface IAtividadesRepository
{
    Task<IEnumerable<Atividades>> GetAllAsync();
    Task<Atividades> GetByIdAsync(Guid id);
    Task AddAsync(Atividades atividade);
    Task UpdateAsync(Atividades atividade);
    Task DeleteAsync(Guid id);
}
