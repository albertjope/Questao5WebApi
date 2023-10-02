using Questao5WebApi.Data.Dto;
using Questao5WebApi.Models;

namespace Questao5WebApi.Services;

public interface IMovimentacaoService
{
    Task<Movimentacao> Incluir(CreateMovimentacaoDto movimentacao);

}
