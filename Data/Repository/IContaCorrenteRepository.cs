using Questao5WebApi.Data.Dto;

namespace Questao5WebApi.Data.Repository
{
    public interface IContaCorrenteRepository
    {
        Task<ReadSaldoContaCorrenteDto> GetSaldoByIdConta(string idConta);
    }
}
