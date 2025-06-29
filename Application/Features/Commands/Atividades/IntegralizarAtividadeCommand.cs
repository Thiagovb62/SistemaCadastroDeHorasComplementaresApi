using MediatR;

namespace SistemaCadastroDeHorasApi.Application.Features.Commands;

public class IntegralizarAtividadeCommand : IRequest
{
    public Guid AtividadeId { get; set; }
}