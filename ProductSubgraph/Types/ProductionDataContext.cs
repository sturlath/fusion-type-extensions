// -----------------------------------------------------------------------
// <copyright file="ProductQueries.cs" company="Marel hf.">
// Copyright (c) Marel hf. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------


// -----------------------------------------------------------------------
// <copyright file="ProductQueries.cs" company="Marel hf.">
// Copyright (c) Marel hf. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;

namespace ProductSubgraph.Types;

public class ProductionDataContext : DbContext
{
    public ProductionDataContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(product =>
        {
            product.ToTable("Products");

            product.HasKey(e => e.Id);
        });

        base.OnModelCreating(modelBuilder);
    }
}