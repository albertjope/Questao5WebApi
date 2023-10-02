using Questao5WebApi.Data.Dto;
using Questao5WebApi.Data.Repository;
using Questao5WebApi.Models;

namespace Questao5WebApi.Services
{
    public class IdempotencyService : IIdempotencyService
    {
        private readonly IIdempotentRepository _idempotentRepository;
        public IdempotencyService(IIdempotentRepository idempotentRepository) => _idempotentRepository = idempotentRepository;

        public async Task<Idempotencia> AddIdempotentKey(Idempotencia idempotencia)
        {

            var result = await _idempotentRepository.Add(idempotencia);

            return result;
        }

        public async Task<Idempotencia> GetIdempotencyByKey(string key)
        {
            var result = await _idempotentRepository.GetIdempotencyByKey(key);

            return result;
        }
    }
}
