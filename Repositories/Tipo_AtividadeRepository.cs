using Microsoft.EntityFrameworkCore;
using SistemaCadastroDeHorasApi.Context;
using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.ENUMS;

namespace SistemaCadastroDeHorasApi.Repositories.Contracts;

public class Tipo_AtividadeRepository : ITipo_AtividadeRepository

{
    private readonly DataContext _context;
    
    public Tipo_AtividadeEnum? ObterTipoAtividadePorNome(string nome)
    {
        return Tipo_AtividadeEnumExtensions.FromString(nome);
    }
    public Tipo_AtividadeRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Models.Tipo_Atividade>> GetAllAsync()
    {
        return await Task.FromResult(_context.TiposAtividade.AsEnumerable());
         
    }

    public Task<Tipo_Atividade> GetByNomeAsync(string nome)
    {
        var tipoAtividadeEnum = ObterTipoAtividadePorNome(nome)
            ?? throw new ArgumentException($"Tipo de atividade '{nome}' não é válido.", nameof(nome));

        var tipoAtividade = _context.TiposAtividade.FirstOrDefault(t => t.nome == tipoAtividadeEnum);

        if (tipoAtividade == null)
        {
            throw new KeyNotFoundException($"Tipo de atividade '{nome}' não encontrado.");
        }

        return Task.FromResult(tipoAtividade);
        
    }
    

    public Task<Tipo_Atividade> GetByIdAsync(int id)
    {
        var tipoAtividade = _context.TiposAtividade.FirstOrDefaultAsync(t => t.Id == id).Result;
        if (tipoAtividade == null)
        {
            throw new KeyNotFoundException($"Tipo de atividade com ID {id} não encontrado.");
        }
        return Task.FromResult(tipoAtividade);
    }
}