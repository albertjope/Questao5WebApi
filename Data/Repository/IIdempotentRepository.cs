using Questao5WebApi.Data.Context;
using Questao5WebApi.Data.Dto;
using Questao5WebApi.Models;

namespace Questao5WebApi.Data.Repository
{
    public interface IIdempotentRepository
    {
        public Task<Idempotencia> Add(Idempotencia idempotencia);
        Task<Idempotencia> GetIdempotencyByKey(string key);
    }
}
