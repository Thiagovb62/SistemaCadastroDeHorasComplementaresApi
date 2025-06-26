using Microsoft.EntityFrameworkCore;
using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Context;

namespace SistemaCadastroDeHorasApi.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly DataContext _context;

    public UsuarioRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public async Task<Usuario> GetByIdAsync(int id)
    {
        Usuario usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null)
        {
            throw new KeyNotFoundException($"Usuário com ID {id} não encontrado.");
        }
        return  usuario;
    }

    public async Task<Usuario> AddAsync(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<Usuario> UpdateAsync(Usuario usuario)
    {
        _context.Usuarios.Update(usuario);
        await _context.SaveChangesAsync();
        return usuario;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var usuario = await _context.Usuarios.FindAsync(id);
        if (usuario == null) return false;

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<Usuario> GetByMatriculaAsync(int matricula)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Matricula == matricula);
        if (usuario == null)
        {
            throw new KeyNotFoundException($"Usuário com matrícula {matricula} não encontrado.");
        }
        return usuario;
        
    }

    public async Task GetByMatriculaToCreateUserAsync(int matricula)
    {
        var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Matricula == matricula);
        
        if (usuario != null)
        {
            throw new BadHttpRequestException("Usuário já existe com esta matrícula.");
        }
    }
}
