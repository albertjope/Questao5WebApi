using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5WebApi.Data.Dto;
using Questao5WebApi.Services.Commands;
using Questao5WebApi.Services.Queries;

namespace Questao5WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContaCorrenteController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContaCorrenteController(IMediator mediator) => _mediator = mediator;

    [HttpGet()]
    public async Task<ActionResult<ReadSaldoContaCorrenteDto>> GetSaldoByIdConta(string idConta)
    {
        var conta = (ReadSaldoContaCorrenteDto) await _mediator.Send(new ContaCorrenteGetByIdCommand(idConta));

        return Ok(conta);
    }

}
