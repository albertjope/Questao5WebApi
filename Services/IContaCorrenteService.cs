using Questao5WebApi.Data.Dto;

namespace Questao5WebApi.Services;

public interface IContaCorrenteService
{
    Task<ReadSaldoContaCorrenteDto> GetSaldoByIdConta(string idConta);
}
