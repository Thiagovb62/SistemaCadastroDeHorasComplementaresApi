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
    private readonly IAtividadesRepository _atividadesRepository;
    
    public AtividadeUsuarioRepository(DataContext context, UsuarioRepository usuarioRepository, IAtividadesRepository atividadesRepository)
    {
        _context = context;
        _atividadesRepository = atividadesRepository;
        _usuarioRepository = usuarioRepository;
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

    public Task<IEnumerable<AtividadeUsuario>> GetAllByUserMatriculaAsync(int usuarioId)
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

    public Task AddAsync(Atividades atividade,int matricula)
    {
        
        if (atividade == null)
        {
            throw new ArgumentNullException(nameof(atividade), "Atividade não pode ser nula.");
        }
        
        Usuario usuario = _usuarioRepository.GetByMatriculaAsync(matricula).Result;
        

        var atividadeUsuario = new AtividadeUsuario
        {
            Id = Guid.NewGuid(),
            Usuario = usuario,
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
}