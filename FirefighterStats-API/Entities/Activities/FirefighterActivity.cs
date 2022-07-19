// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="FirefighterActivity.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace FirefighterStats.Entities.Activities;

using System.ComponentModel.DataAnnotations;
using FirefighterStats.Utils;
using JetBrains.Annotations;

[PublicAPI]
public class FirefighterActivity : Activity
{
    private EActivityType activityType;

    /// <inheritdoc />
    public override EActivityType ActivityType
    {
        get => this.activityType;

        set => this.activityType = value switch
        {
            EActivityType.FirefighterActivity => value,
            _ => throw new ArgumentException($"ActivityType must be set to {EActivityType.FirefighterActivity} for the firefighter activities", nameof(value)),
        };
    }

    [Required]
    public Percentage Rate { get; set; } = 100;
}