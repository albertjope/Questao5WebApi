using Dapper;
using Questao5WebApi.Data.Context;
using Questao5WebApi.Data.Dto;
using Questao5WebApi.Models;
using System.Data;

namespace Questao5WebApi.Data.Repository
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly ApiDbContext _context;
        public MovimentacaoRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<Movimentacao> Incluir(CreateMovimentacaoDto movimentacao)
        {
            var idMovimentacao = System.Guid.NewGuid();
            var query = "INSERT INTO movimento (idmovimentacao,idcontacorrente, datamovimento, tipomovimento, valor) VALUES (@IdMovimentacao, @IdContaCorrente, @DataMovimento,@TipoMovimento, @Valor)";
            var parameters = new DynamicParameters();
            parameters.Add("IdMovimentacao", idMovimentacao, DbType.String);
            parameters.Add("IdContaCorrente", movimentacao.IdContaCorrente, DbType.String);
            parameters.Add("DataMovimento", movimentacao.DataMovimento, DbType.String);
            parameters.Add("TipoMovimento", movimentacao.TipoMovimento, DbType.Int16);
            parameters.Add("Valor", movimentacao.Valor, DbType.Double);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

            using (var connection = _context.CreateConnection())
            {
                var id = await connection.QuerySingleAsync<int>(query, parameters);
                var createdMovimentacao = new Movimentacao
                {
                    IdMovimentacao = idMovimentacao,
                    IdContaCorrente = movimentacao.IdContaCorrente,
                    DataMovimento =  movimentacao.DataMovimento,
                    TipoMovimento = movimentacao.TipoMovimento,
                    Valor = movimentacao.Valor,
                };
                return createdMovimentacao;
            }
        }
    }
}
