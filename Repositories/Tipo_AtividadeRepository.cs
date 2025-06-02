using SistemaCadastroDeHorasApi.Context;
using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.ENUMS;

namespace SistemaCadastroDeHorasApi.Repositories;

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