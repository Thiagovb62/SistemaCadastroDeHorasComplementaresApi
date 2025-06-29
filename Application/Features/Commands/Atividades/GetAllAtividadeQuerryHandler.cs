using MediatR;
using SistemaCadastroDeHorasApi.Application.Features.Queries;
using SistemaCadastroDeHorasApi.Models.DTO;
using SistemaCadastroDeHorasApi.Services.Contracts;

namespace SistemaCadastroDeHorasApi.Application.Features.Commands;

public class GetAllAtividadesQueryHandler : IRequestHandler<GetAllAtividadesQuery, IEnumerable<ResAtividadeUsario>>
{
    private readonly IAtividadeUsuarioService _atividadeUsuarioService;

    public GetAllAtividadesQueryHandler(IAtividadeUsuarioService atividadeUsuarioService)
    {
        _atividadeUsuarioService = atividadeUsuarioService;
    }

    public async Task<IEnumerable<ResAtividadeUsario>> Handle(GetAllAtividadesQuery request, CancellationToken cancellationToken)
    {
        return await _atividadeUsuarioService.GetAllByUserMatriculaAsync(request.Matricula);
    }
}