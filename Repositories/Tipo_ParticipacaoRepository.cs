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

    //public async Task<Tipo_Participacao> CreateAsync(Tipo_Participacao tipoParticipacao)
    //{
    //    if (tipoParticipacao == null)
    //    {
    //        throw new ArgumentNullException(nameof(Tipo_Participacao), "O tipo de participação não pode ser nulo.");
    //    }

    //    _context.TiposParticipacao.Add(tipoParticipacao);
    //    await _context.SaveChangesAsync();
    //    return tipoParticipacao;
    //}
}


