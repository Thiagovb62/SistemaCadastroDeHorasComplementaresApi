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
    public async Task<Usuario> GetByMatriculaAsync(string matricula)
    {
        if (string.IsNullOrEmpty(matricula))
        { 
            throw new ArgumentException("Matricula não pode ser nula ou vazia.", nameof(matricula));
        }
        Usuario user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Matricula == matricula);
        return user;
        
    }
}
