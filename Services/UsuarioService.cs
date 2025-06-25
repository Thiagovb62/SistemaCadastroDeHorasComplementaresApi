using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Repositories;
using System.Security.Cryptography;
using System.Text;
using SistemaCadastroDeHorasApi.Models.DTO;
using SistemaCadastroDeHorasApi.Services.Contracts;


namespace SistemaCadastroDeHorasApi.Services;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IAtividadeUsuarioService _atividadeUsuarioService;

    public string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }

    public UsuarioService(IUsuarioRepository usuarioRepository , IAtividadeUsuarioService atividadeUsuarioService)
    {
        _atividadeUsuarioService = atividadeUsuarioService;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<IEnumerable<Usuario>> GetAllAsync()
    {
        return await _usuarioRepository.GetAllAsync();
    }

    public async Task<Usuario> GetByMatriculaAsync(int matricula)
    {
        
        Usuario usuario = await _usuarioRepository.GetByMatriculaAsync(matricula);
        if (usuario == null) throw new BadHttpRequestException("Usuário não encontrado.");
        return usuario;
    }
    public async Task<Usuario> CreateAsync(ReqUserDTO usuario)
    {
        
        var existingUsuario = await _usuarioRepository.GetByMatriculaAsync(usuario.Matricula);
        
        if (existingUsuario != null)
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
        
        
        existingUsuario.Nome = usuario.Nome ?? existingUsuario.Nome;
        existingUsuario.Senha = usuario.Senha != null ? HashPassword(usuario.Senha) : existingUsuario.Senha;
    

        return await _usuarioRepository.UpdateAsync(existingUsuario);
    }

    public async Task<bool> DeleteAsync(int Matricula)
    {
        var existingUsuario = await _usuarioRepository.GetByMatriculaAsync(Matricula);
        if (existingUsuario == null) throw new BadHttpRequestException("Usuário não encontrado.");
        
        var existingAtividadeUsuarios = await _atividadeUsuarioService.GetAllByUserMatriculaAsync(existingUsuario.Matricula);
        
        if (existingAtividadeUsuarios.Any())
        {
            throw new BadHttpRequestException("Usuário não pode ser excluído, pois possui atividades associadas.");
        }
        
        return await _usuarioRepository.DeleteAsync(existingUsuario.Id);
    }
   
}