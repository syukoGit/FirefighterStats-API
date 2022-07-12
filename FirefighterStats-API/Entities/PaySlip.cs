// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="PaySlip.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace FirefighterStats.Entities;

using System.ComponentModel.DataAnnotations;
using FirefighterStats.Utils;
using JetBrains.Annotations;

[PublicAPI]
public class PaySlip
{
    [Key]
    public int Id { get; set; }

    public ICollection<PaySlipLine>? Lines { get; set; }

    [Required]
    public EMonth Month { get; set; }

    [Required]
    [Range(1900, 2100)]
    public int Year { get; set; }
}