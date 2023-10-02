using MediatR;
using Questao5WebApi.Data.Dto;
using Questao5WebApi.Data.Repository;
using Questao5WebApi.Models;

namespace Questao5WebApi.Services;

public class MovimentacaoService : IMovimentacaoService
{
    private readonly IMovimentacaoRepository _movimentacaoRepository;
    private readonly IIdempotencyService _idempotencyService;
    public MovimentacaoService(IMovimentacaoRepository movimentacaoRepository, IIdempotencyService idempotencyService)
    {
        _movimentacaoRepository = movimentacaoRepository;
        _idempotencyService = idempotencyService;
    }

    public async Task<Movimentacao> Incluir(CreateMovimentacaoDto movimentacao)
    {
        try
        {
            CreateMovimentacaoDto dto = new CreateMovimentacaoDto()
            {
                DataMovimento = movimentacao.DataMovimento,
                IdContaCorrente = movimentacao.IdContaCorrente,
                TipoMovimento = movimentacao.TipoMovimento,
                Valor = movimentacao.Valor
            };

            var result = await _movimentacaoRepository.Incluir(dto);
            var idemResult = _idempotencyService.AddIdempotentKey(movimentacao.Idempotencia);
            return result;
        }
        catch(Exception ex)
        {
            return null;
        }
        
    }
}
