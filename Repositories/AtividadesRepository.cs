using Microsoft.EntityFrameworkCore;
using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Context;
using SistemaCadastroDeHorasApi.Models.DTO;

namespace SistemaCadastroDeHorasApi.Repositories;

public class AtividadesRepository : IAtividadesRepository
{
    private readonly DataContext _context;

    public AtividadesRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<Atividades> GetByIdAsync(Guid id)
    {
        var atividade = await _context.Atividades
            .FirstOrDefaultAsync(a => a.Id == id);
        if (atividade == null)
        {
            throw new KeyNotFoundException($"Atividade com ID {id} não encontrada.");
        }
        return atividade;
    }

    public async Task<IEnumerable<Atividades>> GetAllByUserMatriculaAsync(int matricula)
    {
        //para evitar que o get exponha a byte array do comprovante
        return await _context.Atividades
            .Where(a => a.usuario.Matricula == matricula)
            .Select(a => new Atividades
            {
                Id = a.Id,
                TipoAtividadeId = a.TipoAtividadeId,
                TipoAtividade = a.TipoAtividade,
                UsuarioId = a.UsuarioId,
                usuario = a.usuario,
                TipoParticipacaoId = a.TipoParticipacaoId,
                TipoParticipacao = a.TipoParticipacao,
                pais = a.pais,
                titulo = a.titulo,
                nomeInstituicao = a.nomeInstituicao,
                cnpj = a.cnpj,
                dataInicio = a.dataInicio,
                dataFim = a.dataFim,
                dataSubmissao = a.dataSubmissao,
                status = a.status,
                isExecUfc = a.isExecUfc,
                cargaHoraria = a.cargaHoraria,
                qtdHorasUtilizadas = a.qtdHorasUtilizadas,
                categoriaAtividadeComplementarHoras = a.categoriaAtividadeComplementarHoras,
                nomeArquivo = a.nomeArquivo,
                tipoArquivo = a.tipoArquivo
            })
            .ToListAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var atividade = await _context.Atividades
            .FirstOrDefaultAsync(a => a.Id == id);
        if (atividade != null)
        {
            _context.Atividades.Remove(atividade);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new KeyNotFoundException($"Atividade com ID {id} não encontrada.");
        }
    }
    
    public async Task UpdateAsync(Atividades atividade)
    {
         _context.Atividades.Update(atividade);
        var result = await _context.SaveChangesAsync();
    }
    
    public async Task<ResComprovanteDTO> GetComprovanteAsync(Guid id)
    {
        var comprovante = await _context.Atividades
            .Where(a => a.Id == id)
            .Select(a => new ResComprovanteDTO(
                a.comprovante,
                a.nomeArquivo,
                a.tipoArquivo
            )).FirstOrDefaultAsync();
        if (comprovante == null) throw new KeyNotFoundException("Não foi possivel encontrar o comprovante da atividade.");

        return comprovante;
    }

    public Task<IEnumerable<Atividades>> GetByStatusAsync(string status)
    {
        if (string.IsNullOrEmpty(status))
        {
            throw new ArgumentException("Status não pode ser nulo ou vazio.", nameof(status));
        }

        var atividades = _context.Atividades
            .Where(a => a.status.ToString().Equals(status, StringComparison.OrdinalIgnoreCase))
            .AsEnumerable();

        return Task.FromResult(atividades);
    }
}
