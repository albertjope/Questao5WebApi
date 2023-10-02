using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5WebApi.Data.Dto;
using Questao5WebApi.Models;
using Questao5WebApi.Services.Commands;

namespace Questao5WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovimentacaoController : ControllerBase
{
    private readonly IMediator _mediator;
    public MovimentacaoController(IMediator mediator) {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Movimentacao>> Post([FromBody] CreateMovimentacaoDto movimentacao)
    {
        try
        {
            await _mediator.Send(new MovimentacaoCreateCommand(movimentacao));
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
 
}
