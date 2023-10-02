using MediatR;
using Questao5WebApi.Data.Context;
using Questao5WebApi.Models;

namespace Questao5WebApi.Services.Commands
{
    public class MovimentacaoCreateCommandHandler : IRequestHandler<MovimentacaoCreateCommand>
    {
        private readonly IMovimentacaoService _movimentacaoService;
        public MovimentacaoCreateCommandHandler(IMovimentacaoService movimentacaoService) => _movimentacaoService = movimentacaoService;

        public async Task Handle(MovimentacaoCreateCommand request, CancellationToken cancellationToken)
        {
            var result = await _movimentacaoService.Incluir(request.movimentacao);

            return;
        }

    }

}
