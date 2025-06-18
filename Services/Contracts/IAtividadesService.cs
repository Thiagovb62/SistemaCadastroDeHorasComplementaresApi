using SistemaCadastroDeHorasApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaCadastroDeHorasApi.Models.DTO;

namespace SistemaCadastroDeHorasApi.Services;

public interface IAtividadesService
{
    Task<IEnumerable<Atividades>> GetAll();
    Task<Atividades> GetById(Guid id);
    Task Create(Atividades atividade);
    Task Update(Atividades atividade);
    Task Delete(Guid id);
}
