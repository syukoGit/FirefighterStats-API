// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="PaySlipPatchUpdateDTO.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace FirefighterStats.DTO.PaySlip;

using System.ComponentModel.DataAnnotations;
using FirefighterStats.DTO.PaySlipLine;
using FirefighterStats.Utils;
using JetBrains.Annotations;

[PublicAPI]
public class PaySlipPatchUpdateDTO
{
    public ICollection<PaySlipLinePatchUpdateDTO>? Lines { get; set; }

    public EMonth Month { get; set; }

    [Range(1890, 2100, ErrorMessage = "Year must be between 1890 and 2100")]
    public int Year { get; set; }
}