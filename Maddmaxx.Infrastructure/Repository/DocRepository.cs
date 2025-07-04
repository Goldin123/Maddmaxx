using Dapper;
using Maddmaxx.Domain.Entities;
using Maddmaxx.Domain.Interfaces;
using Maddmaxx.Infrastructure.Factory;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Maddmaxx.Infrastructure.Repository;

public class DocRepository(ISqlConnectionFactory connectionFactory, ILogger<DocRepository> logger) : IDocRepository
{
    public async Task<long> CreateAsync(Doc doc)
    {
        ArgumentNullException.ThrowIfNull(doc);

        try
        {
            using var connection = connectionFactory.CreateConnection();
            var parameters = new DynamicParameters();
            parameters.Add("@content", doc.Content, DbType.String);
            parameters.Add("@contentType", doc.ContentType, DbType.String);

            var insertedId = await connection.ExecuteScalarAsync<long>(
                "dbo.InsertDoc",
                parameters,
                commandType: CommandType.StoredProcedure
            );

            return insertedId;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error inserting document into Docs table. ContentType: {ContentType}", doc.ContentType);
            throw;
        }
    }
}
