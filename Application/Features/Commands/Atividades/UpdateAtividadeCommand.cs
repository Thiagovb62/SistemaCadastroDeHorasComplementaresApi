using MediatR;
using SistemaCadastroDeHorasApi.Models.DTO;

namespace SistemaCadastroDeHorasApi.Application.Features.Commands;

public class UpdateAtividadeCommand : IRequest<string>
{
    public Guid AtividadeId { get; set; }
    public ReqUpdateAtividadeDTO Dto { get; set; }
}