using Questao5WebApi.Data.Context;
using Questao5WebApi.Data.Dto;
using Questao5WebApi.Models;

namespace Questao5WebApi.Data.Repository
{
    public interface IMovimentacaoRepository
    {
        public Task<Movimentacao> Incluir(CreateMovimentacaoDto movimentacao);
    }
}
