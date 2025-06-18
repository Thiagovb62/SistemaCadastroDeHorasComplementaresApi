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

    public async Task<IEnumerable<Atividades>> GetByUserIdAsync(int id)
    {
        return await _context.Atividades
            .Where(a => a.UsuarioId == id)
            .ToListAsync();
    }
    
    public async Task DeleteAsync(Guid id)
    {
        var atividade = await _context.Atividades
            .FirstOrDefaultAsync(a => a.Id == id);
        if (atividade != null)
        {
            _context.Atividades.Remove(atividade);
            await _context.SaveChangesAsync();
        }
    }
}
