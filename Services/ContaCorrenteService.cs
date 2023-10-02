using Questao5WebApi.Data.Dto;
using Questao5WebApi.Data.Repository;

namespace Questao5WebApi.Services;

public class ContaCorrenteService : IContaCorrenteService
{
    private readonly IContaCorrenteRepository _contaCorrenteRepository;
    public ContaCorrenteService(IContaCorrenteRepository contaCorrenteRepository)=> _contaCorrenteRepository = contaCorrenteRepository;

    public async Task<ReadSaldoContaCorrenteDto> GetSaldoByIdConta(string idConta)
    {
        var result = await _contaCorrenteRepository.GetSaldoByIdConta(idConta);

        return result;
    }
}
