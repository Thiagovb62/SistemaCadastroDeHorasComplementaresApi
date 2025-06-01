using SistemaCadastroDeHorasApi.Context;
using SistemaCadastroDeHorasApi.Models;

namespace SistemaCadastroDeHorasApi.Repositories;

public class Tipo_AtividadeRepository : ITipo_AtividadeRepository

{
    private readonly DataContext _context;
    public Tipo_AtividadeRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Models.Tipo_Atividade>> GetAllAsync()
    {
        return await Task.FromResult(_context.TiposAtividade.AsEnumerable());
         
    }

    public async Task<Tipo_Atividade> CreateAsync(Tipo_Atividade tipoAtividade)
    {
        if (tipoAtividade == null)
        {
            throw new ArgumentNullException(nameof(tipoAtividade), "Tipo de atividade não pode ser nulo.");
        }

        _context.TiposAtividade.Add(tipoAtividade);
        await _context.SaveChangesAsync();
        return tipoAtividade;
    }
    
}