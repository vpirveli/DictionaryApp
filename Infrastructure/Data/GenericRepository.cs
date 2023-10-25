namespace Infrastructure.Data;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    IDbConnection _connection;
    private readonly string tableName;
    public GenericRepository(IDbConnection connection)
    {
        _connection = connection;
        tableName = typeof(TEntity).Name;
    }

    public Task<IEnumerable<TEntity>> CustomQueryAsync()
    {
        throw new NotImplementedException();
    }


    public async Task<TEntity> GetById(Guid id)
    {
        string query = $"SELECT * FROM {tableName} WHERE id = @id";

        var result = await _connection.QuerySingleOrDefaultAsync<TEntity>(query, new { id });

        return result;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var query = $"SELECT * FROM {tableName}";

        return await _connection.QueryAsync<TEntity>(query);
    }

    public async Task<TEntity> GetByDescription(string description)
    {
        var query = $"SELECT * FROM {tableName} WHERE Description = @description";
        return await _connection.QuerySingleOrDefaultAsync<TEntity>(query, new { description });
    }

    public async Task<IEnumerable<TEntity>> GetAllByForeignKeyAsync(Guid id, string? propertyName)
    {
        var query = $"SELECT * FROM {tableName} WHERE {propertyName} = @id";

        var result = await _connection.QueryAsync<TEntity>(query, new { id });

        return result;
    }

    public async Task<TEntity> GetByPropertyValue(string term)
    {
        var query = $"SELECT * FROM {tableName} WHERE term = @term";
        return await _connection.QuerySingleOrDefaultAsync<TEntity>(query, new { term });
    }
}
