namespace ProductSubgraph.Types;


/// <summary>
/// Helper to seed database with data
/// </summary>
public class DatabaseHelper
{
    public static async Task SeedDatabaseAsync(WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<ProductionDataContext>();
        if (await context.Database.EnsureCreatedAsync())
        {
            await context.Products.AddRangeAsync(
                new Product
                {
                    Code = "P1",
                }
                );

            await context.SaveChangesAsync();
        }
    }

}