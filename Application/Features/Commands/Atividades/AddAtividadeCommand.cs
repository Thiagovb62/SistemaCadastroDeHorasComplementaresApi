using MediatR;
using SistemaCadastroDeHorasApi.Models.DTO;

namespace SistemaCadastroDeHorasApi.Application.Features.Commands;

// Application/Features/Atividades/Commands/AddAtividadeCommand.cs

// IRequest significa que é um comando que não retorna valor (void)
public class AddAtividadeCommand : IRequest
{
    public ReqAtividadeUsuarioDTO Dto { get; set; }
    public int Matricula { get; set; }
    public IFormFile Comprovante { get; set; }
}