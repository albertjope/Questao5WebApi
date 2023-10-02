using MediatR;
using Questao5WebApi.Data.Dto;
using Questao5WebApi.Data.Repository;
using Questao5WebApi.Models;

namespace Questao5WebApi.Services;

public class MovimentacaoService : IMovimentacaoService
{
    private readonly IMovimentacaoRepository _movimentacaoRepository;
    public MovimentacaoService(IMovimentacaoRepository movimentacaoRepository)=> _movimentacaoRepository = movimentacaoRepository;

    public async Task<Movimentacao> Incluir(CreateMovimentacaoDto movimentacao)
    {
        CreateMovimentacaoDto dto = new CreateMovimentacaoDto()
        {
            DataMovimento = movimentacao.DataMovimento,
            IdContaCorrente = movimentacao.IdContaCorrente,
            TipoMovimento = movimentacao.TipoMovimento,
            Valor = movimentacao.Valor
        };
        
        var result = await _movimentacaoRepository.Incluir(dto); 

        return result;
    }
}
