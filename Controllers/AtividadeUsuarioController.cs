using MediatR;
using Microsoft.AspNetCore.Mvc;
using SistemaCadastroDeHorasApi.Models.DTO;
using SistemaCadastroDeHorasApi.Application.Features.Commands;
using SistemaCadastroDeHorasApi.Application.Features.Queries;


namespace SistemaCadastroDeHorasApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AtividadeUsuarioController : ControllerBase
{
    private readonly IMediator _mediator;

    // O controller agora só depende do IMediator
    public AtividadeUsuarioController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("atividade/all/{matricula}")]
    public async Task<IActionResult> GetAll([FromRoute] int matricula)
    {
        // Cria e envia uma query para buscar os dados
        var query = new GetAllAtividadesQuery { Matricula = matricula };
        var atividadesUsuarios = await _mediator.Send(query);
        return Ok(atividadesUsuarios);
    }

    [HttpPost("add/atividade/{matricula}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Add([FromForm] ReqAtividadeUsuarioDTO dto, [FromRoute] int matricula)
    {
        // Cria e envia um comando para adicionar a atividade
        var command = new AddAtividadeCommand
        {
            Dto = dto,
            Matricula = matricula,
            Comprovante = dto.comprovante
        };
        await _mediator.Send(command);
        return Ok("Atividade adicionada com sucesso");
    }

    [HttpPut("atividade/{atividadeId}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Update([FromForm] ReqUpdateAtividadeDTO dto, [FromRoute] Guid atividadeId)
    {
        // Cria e envia um comando para atualizar a atividade
        var command = new UpdateAtividadeCommand { Dto = dto, AtividadeId = atividadeId };
        var updatedAtividade = await _mediator.Send(command);
        return Ok(updatedAtividade);
    }

    [HttpPut("atividade/integralizar/{atividadeId}")]
    public async Task<IActionResult> Integralizar([FromRoute] Guid atividadeId)
    {
        // Cria e envia um comando para integralizar as horas
        var command = new IntegralizarAtividadeCommand { AtividadeId = atividadeId };
        await _mediator.Send(command);
        return Ok("Atividade integralizada com sucesso");
    }

    [HttpDelete("delete/atividade/{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        // Cria e envia um comando para deletar a atividade
        var command = new DeleteAtividadeCommand { AtividadeId = id };
        await _mediator.Send(command);
        return Ok("Atividade deletada com sucesso");
    }
    
}