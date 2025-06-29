using MediatR;

namespace SistemaCadastroDeHorasApi.Application.Features.Commands;

public class DeleteAtividadeCommand : IRequest<string>
{
    public Guid AtividadeId { get; set; }
}