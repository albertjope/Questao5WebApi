using Questao5WebApi.Data.Dto;
using Questao5WebApi.Models;

namespace Questao5WebApi.Services
{
    public interface IIdempotencyService
    {
        Task<Idempotencia> AddIdempotentKey(Idempotencia idempotencia);
        Task<Idempotencia> GetIdempotencyByKey(string key);
    }
}
