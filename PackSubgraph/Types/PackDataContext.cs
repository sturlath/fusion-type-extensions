// -----------------------------------------------------------------------
// <copyright file="PackQueries.cs" company="Marel hf.">
// Copyright (c) Marel hf. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Marel.DFS.ProductionService.Types;

// -----------------------------------------------------------------------
// <copyright file="PackQueries.cs" company="Marel hf.">
// Copyright (c) Marel hf. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Microsoft.EntityFrameworkCore;

namespace PackSubgraph.Types;

public class PackDataContext : DbContext
{
    public PackDataContext()
    {
    }

    public PackDataContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Pack> Packs => Set<Pack>();
    //public DbSet<Pallet> Pallets => Set<Pallet>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Pack>(pack =>
        //{
        //    pack.ToTable("Packs");
        //    pack.HasKey(e => e.Id);

        //    //pack.HasOne(pack => pack.Pallet)
        //    //              .WithMany(pallet => pallet.Packs)
        //    //              .HasForeignKey(pack => pack.PalletId)
        //    //              .OnDelete(DeleteBehavior.Restrict);

        //    pack.HasIndex(pack => pack.PackId).IsUnique();
        //});

        //modelBuilder.Entity<Pallet>(pallet =>
        //{
        //    pallet.ToTable("Pallets");

        //    //pallet.HasMany(e => e.Packs)
        //    //      .WithOne(w => w.Pallet)
        //    //      .HasForeignKey(w => w.PalletId)
        //    //      .OnDelete(DeleteBehavior.Restrict)
        //    //      .IsRequired();

        //    pallet.HasKey(e => e.Id);
        //});

        base.OnModelCreating(modelBuilder);
    }
}