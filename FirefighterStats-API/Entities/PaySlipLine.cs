// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="PaySlipLine.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace FirefighterStats.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JetBrains.Annotations;

[PublicAPI]
public class PaySlipLine
{
    public int ActivityId { get; set; }

    [Required]
    public DateTime EndDateTime { get; set; }

    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(PaySlip.Id))]
    public int PaySlipId { get; set; }

    public int? Rate { get; set; }

    [Required]
    public DateTime StartDateTime { get; set; }

    [Required]
    public double UnitAmount { get; set; }
}