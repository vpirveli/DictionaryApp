global using Dapper;
global using System.Data;
global using Domain.Abstraction;

using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DictionaryDpContext>();
        services.AddScoped<DictionaryDbContext>();
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped(typeof(IGenericEFRepository<>), typeof(GenericEFRepository<>));
        services.AddDbContext(configuration);
        services.AddDpContext(configuration);

        return services;
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DictionaryDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("ConnectionString"));
        });
    }

    private static void AddDpContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDbConnection>((sp) => new NpgsqlConnection(configuration.GetConnectionString("ConnectionString")));
    }
}
