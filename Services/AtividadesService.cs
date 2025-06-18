using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Repositories;

namespace SistemaCadastroDeHorasApi.Services;

public class AtividadesService : IAtividadesService
{
    private readonly IAtividadesRepository _repository;

    public AtividadesService(IAtividadesRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Atividades>> GetAll()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Atividades> GetById(Guid id)
    {
        return await _repository.GetByIdAsync(id);
    }

    public async Task Create(Atividades atividade)
    {
        await _repository.AddAsync(atividade);
    }

    public async Task Update(Atividades atividade)
    {
        await _repository.UpdateAsync(atividade);
    }

    public async Task Delete(Guid id)
    {
        await _repository.DeleteAsync(id);
    }
}
