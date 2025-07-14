using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using SistemaCadastroDeHorasApi.Models;
using SistemaCadastroDeHorasApi.Models.DTO;
using SistemaCadastroDeHorasApi.Services;
using SistemaCadastroDeHorasApi.Services.Contracts;
using SistemaCadastroDeHorasApi.Services.Factory;

namespace SistemaCadastroDeHorasApi.Controllers;
[ApiController]
[Microsoft.AspNetCore.Components.Route("api/[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class AtividadeUsuarioController : ControllerBase
{

    private readonly IAtividadeUsuarioService _atividadeUsuarioService;
    
    private readonly IUsuarioService _usuarioService;

    private readonly IComprovanteService _comprovanteService;


    public AtividadeUsuarioController(IAtividadeUsuarioService atividadeUsuarioService, IUsuarioService usuarioService, IComprovanteService comprovanteService)
    {
        _usuarioService = usuarioService;
        _atividadeUsuarioService = atividadeUsuarioService;
        _comprovanteService = comprovanteService;
    }

    [HttpGet("atividade/all/{matricula}")]
    public async Task<IActionResult> GetAll([FromRoute] int matricula)
    {
        var atividadesUsuarios = await _atividadeUsuarioService.GetAllByUserMatriculaAsync(matricula);
        return Ok(atividadesUsuarios);
    }
    
    [HttpGet("atividade/hora/details/{matricula}")]
    public async Task<IActionResult> GetHorasDetails([FromRoute] int matricula)
    {
        var horasDetails = await _atividadeUsuarioService.GetHorasDeatailsByMatricula(matricula);
        return Ok(horasDetails);
    }

    [HttpPost("add/atividade/{matricula}")]
    [Consumes("multipart/form-data")]
    public IActionResult Add([FromForm] ReqAtividadeUsuarioDTO dto, [FromRoute] int matricula)
    {
        _atividadeUsuarioService.AddAsync(dto, matricula, dto.comprovante);
        return Ok("Atividade adicionada com sucesso");
    }
    [HttpPut("atividade/{atividadeId}")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> Update([FromForm] ReqUpdateAtividadeDTO dto, [FromRoute] Guid atividadeId)
    {
        var updatedAtividade = await _atividadeUsuarioService.UpdateAsync(dto, atividadeId);
        return Ok(updatedAtividade);
    }
    [HttpPut("atividade/integralizar/{atividadeId}")]
    public IActionResult Integralizar([FromRoute] Guid atividadeId)
    {
        _atividadeUsuarioService.IntegralizarHoras(atividadeId);
        return Ok("Atividade integralizada com sucesso");
    }
    
    
    [HttpDelete("delete/atividade/{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        await _atividadeUsuarioService.DeleteByAtividadeIdAsync(id);
        return Ok("Atividade deletada com sucesso");
    }

    [HttpGet("atividade/comprovante/{matricula}/{atividadeId}")]
    public async Task<IActionResult> GetComprovante([FromRoute] Guid atividadeId)
    {
        var comprovante = await _comprovanteService.GetComprovante(atividadeId);

        return File(comprovante, "application/pdf", "comprovante.pdf");
    }
    
}