// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="PaySlipLineDTO.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace FirefighterStats.DTO.PaySlipLine;

using JetBrains.Annotations;

[PublicAPI]
public sealed class PaySlipLineDTO
{
    public DateTime EndDateTime { get; set; }

    public int Id { get; set; }

    public DateTime StartDateTime { get; set; }
}