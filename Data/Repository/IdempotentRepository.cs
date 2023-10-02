using Dapper;
using Questao5WebApi.Data.Context;
using Questao5WebApi.Data.Dto;
using Questao5WebApi.Models;
using System.Data;

namespace Questao5WebApi.Data.Repository
{
    public class IdempotentRepository : IIdempotentRepository
    {
        private readonly ApiDbContext _context;
        public IdempotentRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Idempotencia> Add(Idempotencia idempotencia)
        {
            idempotencia.Resultado = enumTipoResultado.Started;
            var query = "INSERT INTO movimento (chave_idempotencia,requisicao, resultado) VALUES (@Chave_Idempotencia, @Requisicao, @Resultado)";
            var parameters = new DynamicParameters();
            parameters.Add("Chave_Idempotencia", idempotencia.Chave_Idempotencia, DbType.String);
            parameters.Add("Requisicao", idempotencia.Requisicao, DbType.String);
            parameters.Add("Resultado", idempotencia.Resultado.ToString(), DbType.String);

            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);
                return idempotencia;
            }
        }

        public async Task<Idempotencia> GetIdempotencyByKey(string key)
        {
            var query = "SELECT * FROM idempotencia WHERE chave_idempotencia = @Chave_Idempotencia;";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("Chave_Idempotencia", key, DbType.String);
                var idempotencia = await connection.QueryFirstAsync(query, parameters);

                return idempotencia();
            }
        }

    }
}
