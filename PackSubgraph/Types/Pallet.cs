// -----------------------------------------------------------------------
// <copyright file="PackQueries.cs" company="Marel hf.">
// Copyright (c) Marel hf. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using Marel.DFS.ProductionService.Types;

namespace PackSubgraph.Types;

public class Pallet
{
    public int Id { get; set; }

    public List<Pack> Packs { get; set; } = [];
}