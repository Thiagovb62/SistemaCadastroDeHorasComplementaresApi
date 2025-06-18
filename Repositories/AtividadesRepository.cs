using Microsoft.EntityFrameworkCore;
using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Context;

namespace SistemaCadastroDeHorasApi.Repositories;

public class AtividadesRepository : IAtividadesRepository
{
    private readonly DataContext _context;

    public AtividadesRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Atividades>> GetAllAsync()
    {
        return await _context.Atividades
            .Include(a => a.TipoAtividade)
            .Include(a => a.TipoParticipacao)
            .ToListAsync();
    }

    public async Task<Atividades> GetByIdAsync(Guid id)
    {
        return await _context.Atividades
            .Include(a => a.TipoAtividade)
            .Include(a => a.TipoParticipacao)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task AddAsync(Atividades atividade)
    {
        await _context.Atividades.AddAsync(atividade);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Atividades atividade)
    {
        _context.Atividades.Update(atividade);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var atividade = await GetByIdAsync(id);
        if (atividade != null)
        {
            _context.Atividades.Remove(atividade);
            await _context.SaveChangesAsync();
        }
    }
}
