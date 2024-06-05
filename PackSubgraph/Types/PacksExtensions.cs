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
    [BindField(nameof(Pack.ProductCode))]
    // 👆This should make fusion replace the ProductCode field in Pack, with the product.
    // But it doesn´t... what am I missing? 🤔 
    public Product Product([Parent] Pack pack) => new(pack.ProductCode);
}

public record Product(string? Code);
