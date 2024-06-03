// -----------------------------------------------------------------------
// <copyright file="PackQueries.cs" company="Marel hf.">
// Copyright (c) Marel hf. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Marel.DFS.ProductionService.Types
{
    public class Pack
    {
        public int Id { get; set; }

        public int PackId { get; set; }

        public string? ProductCode { get; set; }

        public string? Code { get; set; } = default!;

        //public int PalletId { get; set; }
        //public Pallet? Pallet { get; set; }

    }
}