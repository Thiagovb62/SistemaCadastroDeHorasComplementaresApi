using MediatR;
using SistemaCadastroDeHorasApi.Services.Contracts;

namespace SistemaCadastroDeHorasApi.Application.Features.Commands;


// Implementa o handler para o nosso comando
public class AddAtividadeCommandHandler : IRequestHandler<AddAtividadeCommand>
{
    // O handler agora recebe as dependências que o serviço usava
    private readonly IAtividadeUsuarioService _atividadeUsuarioService;

    public AddAtividadeCommandHandler(IAtividadeUsuarioService atividadeUsuarioService)
    {
        _atividadeUsuarioService = atividadeUsuarioService;
    }

    // A lógica de negócio agora vive aqui
    public async Task Handle(AddAtividadeCommand request, CancellationToken cancellationToken)
    {
        _atividadeUsuarioService.AddAsync(request.Dto, request.Matricula);
        
        // Como o método original não era async, retornamos Task.CompletedTask
        await Task.CompletedTask;
    }
}