using MediatR;
using SistemaCadastroDeHorasApi.Services.Contracts;

namespace SistemaCadastroDeHorasApi.Application.Features.Commands;

public class IntegralizarAtividadeCommandHandler : IRequestHandler<IntegralizarAtividadeCommand>
{
    private readonly IAtividadeUsuarioService _atividadeUsuarioService;

    public IntegralizarAtividadeCommandHandler(IAtividadeUsuarioService atividadeUsuarioService)
    {
        _atividadeUsuarioService = atividadeUsuarioService;
    }

    public Task Handle(IntegralizarAtividadeCommand request, CancellationToken cancellationToken)
    {
        _atividadeUsuarioService.IntegralizarHoras(request.AtividadeId);
        return Task.CompletedTask;
    }
}