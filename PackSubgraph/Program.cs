using Microsoft.EntityFrameworkCore;
using PackSubgraph.Types;
using ProductSubgraph.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDbContextPool<PackDataContext>(
        o => o.UseSqlite("Data Source=packdata.db"));

builder.Logging.ClearProviders().AddConsole().AddDebug().SetMinimumLevel(LogLevel.Trace);

builder.Services
    .AddGraphQLServer()
    .RegisterDbContext<PackDataContext>()
    .AddErrorFilter<CustomErrorFilter>()
    .AddFiltering()
    .AddSorting()
    .AddQueryType()
    .AddTypeExtension<PackQueries>()   //.AddQueryType<PackQueries>()
    .AddTypeExtension<PacksExtensions>() //<-- Gets extends Pack with Product
    .AddInstrumentation(o => o.RenameRootActivity = true);

var app = builder.Build();

await DatabaseHelper.SeedDatabaseAsync(app);

app.UseHttpsRedirection();

app.MapGraphQL();

await app.RunWithGraphQLCommandsAsync(args);
