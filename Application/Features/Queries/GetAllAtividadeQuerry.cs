// Em: Application/Features/Atividades/Queries/GetAllAtividadesQuery.cs
using MediatR;
using SistemaCadastroDeHorasApi.Models.DTO;

namespace SistemaCadastroDeHorasApi.Application.Features.Queries;

public class GetAllAtividadesQuery : IRequest<IEnumerable<ResAtividadeUsario>>
{
    public int Matricula { get; set; }
}