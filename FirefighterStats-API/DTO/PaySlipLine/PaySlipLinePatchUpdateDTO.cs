// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="PaySlipLinePatchUpdateDTO.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace FirefighterStats.DTO.PaySlipLine;

using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

[PublicAPI]
public class PaySlipLinePatchUpdateDTO
{
    [DataType(DataType.DateTime)]
    public DateTime EndDateTime { get; set; }

    [DataType(DataType.DateTime)]
    public DateTime StartDateTime { get; set; }
}