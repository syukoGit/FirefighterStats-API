// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="Activity.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace FirefighterStats.Entities;

using System.ComponentModel.DataAnnotations;
using FirefighterStats.Utils;
using JetBrains.Annotations;

[PublicAPI]
public abstract class Activity
{
    [Required]
    public abstract EActivityType ActivityType { get; set; }

    [Required]
    public DateTime EndDateTime { get; set; }

    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime StartDateTime { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;
}