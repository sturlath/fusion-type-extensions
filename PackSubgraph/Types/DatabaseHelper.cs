using Marel.DFS.ProductionService.Types;
using PackSubgraph.Types;

namespace ProductSubgraph.Types;


/// <summary>
/// Helper to seed database with data
/// </summary>
public class DatabaseHelper
{
    public static async Task SeedDatabaseAsync(WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<PackDataContext>();
        if (await context.Database.EnsureCreatedAsync())
        {
            await context.Packs.AddRangeAsync(
                new Pack
                {
                    ProductCode = "P1",
                    // Code = "Code 1"
                }
                );

            await context.SaveChangesAsync();
        }
    }

}