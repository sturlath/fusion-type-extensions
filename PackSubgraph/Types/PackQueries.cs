// -----------------------------------------------------------------------
// <copyright file="PackQueries.cs" company="Marel hf.">
// Copyright (c) Marel hf. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace PackSubgraph.Types;
using Marel.DFS.ProductionService.Types;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Pack queries
/// </summary>
[ExtendObjectType(OperationTypeNames.Query)]
[GraphQLDescription("Pack queries")]
public class PackQueries
{
    private readonly ILogger<PackQueries> logger;

    public PackQueries(ILogger<PackQueries> logger)
    {
        this.logger = logger;
    }

    /// <summary>
    /// Get all packs
    /// </summary>
    /// <returns></returns>
    [UsePaging]
    [UseFiltering]
    [GraphQLDescription("Get all packs")]
    public async Task<IQueryable<Pack>> GetPacksAsync([Service(ServiceKind.Synchronized)] PackDataContext context, CancellationToken cancellationToken)
    {
        try
        {
            logger.LogInformation("Getting all pack datas");

            // Use the CancellationToken to check for cancellation
            cancellationToken.ThrowIfCancellationRequested();

            // Asynchronously execute the query while respecting cancellation
            var result = await context.Packs.ToListAsync(cancellationToken);

            return result.AsQueryable();
        }
        catch (OperationCanceledException)
        {
            // Handle cancellation gracefully, such as returning an empty list or null
            return Enumerable.Empty<Pack>().AsQueryable();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while getting all packs");
            throw;
        }
    }
}

[ExtendObjectType<Pack>]
public class PacksExtensions
{
    [BindField("ProductCode")]
    // 👆This will make fusion replace the ProductCode field in Pack, with the product.
    public Product Product([Parent] Pack pack) => new Product(pack.ProductCode);
}
public record Product(string? code);
