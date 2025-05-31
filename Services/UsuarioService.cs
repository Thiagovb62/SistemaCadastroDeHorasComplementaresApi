using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaCadastroDeHorasApi.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioService(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _usuarioRepository.GetAllAsync();
    }

    public async Task<Usuario> GetByIdAsync(int id)
    {
        return await _usuarioRepository.GetByIdAsync(id);
    }

    public async Task<Usuario> CreateAsync(Usuario usuario)
    {
        // Aqui você pode colocar validações extras, hashing de senha, etc.
        return await _usuarioRepository.AddAsync(usuario);
    }

    public async Task<Usuario> UpdateAsync(int id, Usuario usuario)
    {
        var existingUsuario = await _usuarioRepository.GetByIdAsync(id);
        if (existingUsuario == null) return null;

        // Atualize os campos necessários
        existingUsuario.Nome = usuario.Nome;
        existingUsuario.Matricula = usuario.Matricula;
        existingUsuario.Senha = usuario.Senha;
        existingUsuario.Role = usuario.Role;
        existingUsuario.SemestreDeIngresso = usuario.SemestreDeIngresso;

        return await _usuarioRepository.UpdateAsync(existingUsuario);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _usuarioRepository.DeleteAsync(id);
    }
}
