using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Repositories;
using System.Security.Cryptography;
using System.Text;
using SistemaCadastroDeHorasApi.Models.DTO;


namespace SistemaCadastroDeHorasApi.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;

    public string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }

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
        Usuario usuario = await _usuarioRepository.GetByIdAsync(id);
        if (usuario == null) throw new  BadHttpRequestException("Usuário não encontrado.");
        return usuario;
    }

    public async Task<Usuario> CreateAsync(ReqUserDTO usuario)
    {
        if (await _usuarioRepository.GetByMatriculaAsync(usuario.Matricula) != null)
        {
            throw new BadHttpRequestException("Usuário já existe com esta matrícula.");
        }
        Usuario newUsuario = new Usuario
        {
            Nome = usuario.Nome,
            Matricula = usuario.Matricula,
            Senha = HashPassword(usuario.Senha),
            Role = "ALUNO",
            SemestreDeIngresso = usuario.SemestreDeIngresso
        };

        return await _usuarioRepository.AddAsync(newUsuario);
    }

    public async Task<Usuario> UpdateAsync(int id, ReqUpdateUserDTO usuario)
    {
        var existingUsuario = await _usuarioRepository.GetByIdAsync(id);
        if (existingUsuario == null) throw new BadHttpRequestException("Usuário não encontrado.");
        if (await _usuarioRepository.GetByMatriculaAsync(usuario.Matricula) != null && 
            existingUsuario.Matricula != usuario.Matricula)
        {
            throw new BadHttpRequestException("Já existe um usuário com esta matrícula.");
        }
        
        existingUsuario.Nome = usuario.Nome ?? existingUsuario.Nome;
        existingUsuario.Matricula = usuario.Matricula ?? existingUsuario.Matricula;
        existingUsuario.Senha = usuario.Senha != null ? HashPassword(usuario.Senha) : existingUsuario.Senha;
        existingUsuario.SemestreDeIngresso = usuario.SemestreDeIngresso != 0 ? usuario.SemestreDeIngresso : existingUsuario.SemestreDeIngresso;

        return await _usuarioRepository.UpdateAsync(existingUsuario);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existingUsuario = await _usuarioRepository.GetByIdAsync(id);
        if (existingUsuario == null) throw new BadHttpRequestException("Usuário não encontrado.");
        return await _usuarioRepository.DeleteAsync(id);
    }
}