using Dapper;
using Questao5WebApi.Data.Context;
using Questao5WebApi.Data.Dto;
using Questao5WebApi.Models;
using System.Data;

namespace Questao5WebApi.Data.Repository
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly ApiDbContext _context;
        public ContaCorrenteRepository(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<ReadSaldoContaCorrenteDto> GetSaldoByIdConta(string idConta)
        {
            var query = "SELECT * FROM contacorrente WHERE idcontacorrente = @IdConta;";
            using (var connection = _context.CreateConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("IdConta", idConta, DbType.String);
                var conta = await connection.QueryFirstAsync(query,parameters);
                if (conta != null)
                {
                    query = " SELECT idcontacorrente, SUM(ca1.Credito) - SUM(ca1.Debito) AS saldo" +
                            " FROM movimento mov" +
                            " CROSS APPLY (    " +
                            " SELECT    CASE WHEN tipomovimento ='D' THEN valor  ELSE 0 END AS Debito," +
                            "    CASE WHEN tipomovimento ='C' THEN valor  ELSE 0 END AS Credito) AS ca1" +
                            " where idcontacorrente = @IdConta" +
                            " GROUP BY mov.idcontacorrente";
                    var contaSaldo = await connection.QueryFirstAsync(query,parameters);
                    conta.saldo = contaSaldo.saldo;
                    return new ReadSaldoContaCorrenteDto()
                    {
                        Ativo = Convert.ToBoolean(conta.ativo),
                        DataHora = DateTime.Now,
                        IdContaCorrente = System.Guid.Parse(conta.idcontacorrente),
                        Nome = conta.nome,
                        Numero = conta.numero,
                        Saldo = Math.Round(conta.saldo, 2)
                    };
                }

                return new ReadSaldoContaCorrenteDto();
            }
        }
    }
}
