using Microsoft.EntityFrameworkCore;
using ProductSubgraph.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContextPool<ProductionDataContext>(
        o => o.UseSqlite("Data Source=productiondata.db"));

builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<ProductionDataContext>()
    .AddFiltering()
    .AddSorting()
    .AddQueryType()
    .AddTypeExtension<ProductQueries>()
    .AddInstrumentation(o => o.RenameRootActivity = true);

var app = builder.Build();

await DatabaseHelper.SeedDatabaseAsync(app);

app.UseHttpsRedirection();

app.MapGraphQL();

// run dotnet run --schema export --output schema.graphql to create schema.graphql file 
app.RunWithGraphQLCommands(args);
