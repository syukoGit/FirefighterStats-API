// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="PaySlipDTO.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace FirefighterStats.DTO.PaySlip;

using FirefighterStats.DTO.PaySlipLine;
using FirefighterStats.Utils;
using JetBrains.Annotations;

[PublicAPI]
public sealed class PaySlipDTO
{
    public int Id { get; set; }

    public ICollection<PaySlipLineDTO>? Lines { get; set; }

    public EMonth Month { get; set; }

    public int Year { get; set; }
}