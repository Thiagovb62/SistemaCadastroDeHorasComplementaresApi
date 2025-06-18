using Microsoft.EntityFrameworkCore;
using SistemaCadastroDeHorasApi.Context;
using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.ENUMS;

namespace SistemaCadastroDeHorasApi.Repositories;
public class Tipo_ParticipacaoRepository : ITipo_ParticipacaoRepository
{
    private readonly DataContext _context;

    public Tipo_ParticipacaoEnum? ObterTipoParticipacaoPorNome(string nome)
    {
        return Tipo_ParticipacaoEnumExtensions.FromString(nome);
    }

    public Tipo_ParticipacaoRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tipo_Participacao>> GetAllAsync()
    {
        return await Task.FromResult(_context.TiposParticipacao.AsEnumerable());
    }

    public Task<Tipo_Participacao> GetByNomeAsync(string nome)
    {
        var tipoParticipacaoEnum = ObterTipoParticipacaoPorNome(nome)
            ?? throw new ArgumentException($"Tipo de participação '{nome}' não é válido.", nameof(nome));

        var tipoParticipacao = _context.TiposParticipacao.FirstOrDefault(t => t.nome == tipoParticipacaoEnum);

        if (tipoParticipacao == null)
        {
            throw new KeyNotFoundException($"Tipo de participação '{nome}' não encontrado.");
        }

        return Task.FromResult(tipoParticipacao);
    }

    public Task<Tipo_Participacao> getByIdAsync(int id)
    {
        var tipoParticipacao = _context.TiposParticipacao.FirstOrDefaultAsync(t => t.Id == id).Result;
        if (tipoParticipacao == null)
        {
            throw new KeyNotFoundException($"Tipo de participação com ID {id} não encontrado.");
        }
        return Task.FromResult(tipoParticipacao);
    }
    
}


