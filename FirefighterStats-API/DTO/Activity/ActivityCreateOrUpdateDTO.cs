// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="ActivityCreateOrUpdateDTO.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace FirefighterStats.DTO.Activity;

using System.ComponentModel.DataAnnotations;
using FirefighterStats.Utils;
using JetBrains.Annotations;

[PublicAPI]
public class ActivityCreateOrUpdateDTO : IValidatableObject
{
    [Required]
    public EActivityType ActivityType { get; set; }

    [Required]
    public DateTime EndDateTime { get; set; }

    public double? Rate { get; set; }

    [Required]
    public DateTime StartDateTime { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    /// <inheritdoc />
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (this.ActivityType == EActivityType.FirefighterActivity)
        {
            if (this.Rate == null)
            {
                yield return new ValidationResult($"{this.Rate} must be defined for a {EActivityType.FirefighterActivity}", new[]
                {
                    nameof(this.Rate),
                });
            }
        }
        else
        {
            if (this.Rate != null)
            {
                yield return new ValidationResult($"{this.Rate} must be only defined for the {EActivityType.FirefighterActivity}", new[]
                {
                    nameof(this.Rate),
                });
            }
        }

        if (this.EndDateTime <= this.StartDateTime)
        {
            yield return new ValidationResult($"{nameof(this.EndDateTime)} must be after {nameof(this.StartDateTime)}", new[]
            {
                nameof(this.EndDateTime),
            });
        }
    }
}