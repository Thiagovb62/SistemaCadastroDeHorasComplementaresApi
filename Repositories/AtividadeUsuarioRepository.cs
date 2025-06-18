using Microsoft.EntityFrameworkCore;
using SistemaCadastroDeHorasApi.Context;
using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.ENUMS;

using SistemaCadastroDeHorasApi.Repositories.Contracts;

namespace SistemaCadastroDeHorasApi.Repositories;

public class AtividadeUsuarioRepository : IAtividadeUsuarioRepository
{
    
    private readonly DataContext _context;
    private readonly UsuarioRepository _usuarioRepository;
    
    public AtividadeUsuarioRepository(DataContext context, UsuarioRepository usuarioRepository)
    {
        _context = context;
        _usuarioRepository = usuarioRepository;
    }

    public StatusAtividadeEnum? obterStatusAtividadePorNome(string nome)
    {
        return StatusAtividadeEnumExtensions.FromString(nome);
    }
    
    public Task<IEnumerable<AtividadeUsuario>> GetAllAsync()
    {
        
       Task<IEnumerable<AtividadeUsuario>> listaDeAtividades =  Task<IEnumerable<AtividadeUsuario>>.FromResult(_context.AtividadeUsuarios.AsEnumerable());
        return listaDeAtividades;
           
    }

    public Task<AtividadeUsuario> GetByIdAsync(Guid id)
    {
        AtividadeUsuario atividadeUsuario = _context.AtividadeUsuarios.FirstOrDefaultAsync(a => a.Id == id).Result;
        if (atividadeUsuario == null)
        {
            throw new KeyNotFoundException($"Atividade com ID {id} não encontrada.");
        }
        return Task.FromResult(atividadeUsuario);
    }

    public Task<IEnumerable<AtividadeUsuario>> GetByUsuarioIdAsync(int usuarioId)
    {
        var atividades = _context.AtividadeUsuarios
            .Where(a => a.UsuarioId == usuarioId)
            .AsEnumerable();

        return Task.FromResult(atividades);
    }

    public Task<IEnumerable<AtividadeUsuario>> GetByStatusAsync(string status)
    {
        if (string.IsNullOrEmpty(status))
        {
            throw new ArgumentException("Status não pode ser nulo ou vazio.", nameof(status));
        }

        var atividades = _context.AtividadeUsuarios
            .Where(a => a.Status.ToString().Equals(status, StringComparison.OrdinalIgnoreCase))
            .AsEnumerable();

        return Task.FromResult(atividades);
    }

    public Task AddAsync(Atividades atividade,int usuarioId)
    {
        
        if (atividade == null)
        {
            throw new ArgumentNullException(nameof(atividade), "Atividade não pode ser nula.");
        }
        
        Usuario usuario = _usuarioRepository.GetByIdAsync(usuarioId).Result;
        

        var atividadeUsuario = new AtividadeUsuario
        {
            Id = Guid.NewGuid(),
            UsuarioId = usuarioId,
            Usuario = usuario,
            AtividadeId = atividade.Id,
            Atividade = atividade,
            Status = StatusAtividadeEnum.PENDENTE 
        };

        _context.AtividadeUsuarios.Add(atividadeUsuario);
        _context.SaveChanges();

        return Task.CompletedTask;
        
    }

    public Task UpdateAsync(AtividadeUsuario atividadeUsuario)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}