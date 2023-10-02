using MediatR;
using Questao5WebApi.Data.Dto;

namespace Questao5WebApi.Services.Commands;

public class ContaCorrenteGetByIdCommandHandler : IRequestHandler<ContaCorrenteGetByIdCommand, ReadSaldoContaCorrenteDto>
{
    private readonly IContaCorrenteService _contaCorrenteService;
    public ContaCorrenteGetByIdCommandHandler(IContaCorrenteService contaCorrenteService) => _contaCorrenteService = contaCorrenteService;
    public async Task<ReadSaldoContaCorrenteDto> Handle(ContaCorrenteGetByIdCommand request, CancellationToken cancellationToken) =>
        await _contaCorrenteService.GetSaldoByIdConta(request.Id);

}
