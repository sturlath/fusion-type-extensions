// -----------------------------------------------------------------------
// <copyright file="ProductQueries.cs" company="Marel hf.">
// Copyright (c) Marel hf. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;

namespace ProductSubgraph.Types;
[ExtendObjectType(OperationTypeNames.Query)]
//[ObjectType]
[GraphQLDescription("Product queries")]
public class ProductQueries
{
    private readonly ILogger<ProductQueries> logger;

    public ProductQueries(ILogger<ProductQueries> logger)
    {
        this.logger = logger;
    }

    [UsePaging]
    [UseFiltering]
    [GraphQLDescription("Get all Products")]
    public async Task<IQueryable<Product>> GetProductsAsync([Service(ServiceKind.Synchronized)] ProductionDataContext context, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Getting all products");

            // Use the CancellationToken to check for cancellation
            cancellationToken.ThrowIfCancellationRequested();

            // Asynchronously execute the query while respecting cancellation
            var result = await context.Products.ToListAsync(cancellationToken);

            return result.AsQueryable();
        }
        catch (OperationCanceledException)
        {
            // Handle cancellation gracefully, such as returning an empty list or null
            return Enumerable.Empty<Product>().AsQueryable();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while getting all products");
            throw;
        }
    }

    public async Task<Product?> GetProductByCodeAsync([Service(ServiceKind.Synchronized)] ProductionDataContext context, string? code, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Getting product by code: {Code}", code);

            // Use the CancellationToken to check for cancellation
            cancellationToken.ThrowIfCancellationRequested();

            if (code == null)
            {
                return new();
            }

            // Asynchronously execute the query while respecting cancellation
            return await context.Products.FirstOrDefaultAsync(t => t.Code == code!, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while getting product by code: {Code}", code);
            throw;
        }
    }

    [GraphQLDescription("Get Product by id")]
    public async Task<Product?> GetProductById(int id, [Service(ServiceKind.Synchronized)] ProductionDataContext context, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Getting product by id: {Id}", id);

            // Use the CancellationToken to check for cancellation
            cancellationToken.ThrowIfCancellationRequested();

            // Asynchronously execute the query while respecting cancellation
            return await context.Products.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while getting product by id: {Id}", id);
            throw;
        }
    }
}
