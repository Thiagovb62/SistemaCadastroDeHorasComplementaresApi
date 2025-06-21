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

    public async Task<IEnumerable<Atividades>> GetByUserIdAsync(int id)
    {
        //para evitar que o get exponha a byte array do comprovante
        return await _context.Atividades
            .Where(a => a.UsuarioId == id)
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
                isExecUfc = a.isExecUfc,
                cargaHoraria = a.cargaHoraria,
                qtdHorasUtilizadas = a.qtdHorasUtilizadas,
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
        if (comprovante == null) throw new BadHttpRequestException("Não foi possivel encontrar o comprovante da atividade.");

        return comprovante;
    }
}
