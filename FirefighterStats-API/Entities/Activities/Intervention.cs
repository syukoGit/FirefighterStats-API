// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="Intervention.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace FirefighterStats.Entities.Activities;

using System.ComponentModel.DataAnnotations;
using FirefighterStats.Utils;
using JetBrains.Annotations;

[PublicAPI]
public class Intervention : Activity
{
    private EActivityType activityType;

    /// <inheritdoc />
    public override EActivityType ActivityType
    {
        get => this.activityType;

        set => this.activityType = value switch
        {
            EActivityType.PersonalAssistance or EActivityType.Fire or EActivityType.Apr or EActivityType.FireAndApr => value,
            EActivityType.FirefighterActivity => throw new ArgumentException($"ActivityType cannot be set to {value} for an intervention", nameof(value)),
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, null),
        };
    }

    [Required]
    public int InterventionNumber { get; set; }
}