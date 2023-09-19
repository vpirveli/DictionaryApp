using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    internal class DictionaryDpContext
    {
        private readonly string? _connectionString;

        public DictionaryDpContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DapperConnectionString");
        }

        public IDbConnection CreateConnection => new NpgsqlConnection(_connectionString);
    }
}
