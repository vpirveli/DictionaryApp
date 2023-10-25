using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Infrastructure
{
    public class DictionaryDpContext
    {
        private readonly string? _connectionString;

        public DictionaryDpContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConnectionString");
        }

        public IDbConnection CreateConnection => new NpgsqlConnection(_connectionString);
    }
}
