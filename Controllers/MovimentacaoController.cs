using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5WebApi.Data.Dto;
using Questao5WebApi.Models;
using Questao5WebApi.Services;
using Questao5WebApi.Services.Commands;

namespace Questao5WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovimentacaoController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IIdempotencyService _idempotencyService;
    public MovimentacaoController(IMediator mediator, IIdempotencyService idempotencyService) {
        _mediator = mediator;
        _idempotencyService = idempotencyService;
    }

    [HttpPost]
    public async Task<ActionResult<Movimentacao>> Post([FromBody] CreateMovimentacaoDto movimentacao)
    {
        var key = System.Guid.NewGuid();
        try
        {
            Idempotencia? idempotenteKey = null;
            while (idempotenteKey == null)
            {
                idempotenteKey = await _idempotencyService.GetIdempotencyByKey(key.ToString());
                if (idempotenteKey == null)
                {
                    movimentacao.Idempotencia = new Idempotencia() { Chave_Idempotencia = key, Requisicao = "Movimentacao_Post" };
                    await _mediator.Send(new MovimentacaoCreateCommand(movimentacao));
                }

            }

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
 
}
