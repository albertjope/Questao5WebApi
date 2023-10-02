using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Emit;

namespace Questao5WebApi.Data.Context;

public class ApiDbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    public ApiDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = _configuration.GetConnectionString("SqlConnection");
    }
    public IDbConnection CreateConnection()
        => new SqlConnection(_connectionString);

}
