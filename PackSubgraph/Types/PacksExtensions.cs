// -----------------------------------------------------------------------
// <copyright file="PackQueries.cs" company="Marel hf.">
// Copyright (c) Marel hf. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace PackSubgraph.Types;
using Marel.DFS.ProductionService.Types;

[ExtendObjectType<Pack>]
public class PacksExtensions
{
    [BindMember(nameof(Pack.ProductCode))]
    // 👆This makes fusion replace the ProductCode field in Pack, with the product.
    public Product Product([Parent] Pack pack) => new(pack.ProductCode);
}

public record Product(string? Code);
