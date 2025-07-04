using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Maddmaxx.Infrastructure.Factory;

public class SqlConnectionFactory(IConfiguration config, string connectionName = "DefaultConnection") : ISqlConnectionFactory
{
    private readonly string _connectionString = config.GetConnectionString(connectionName) ?? "";

    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
