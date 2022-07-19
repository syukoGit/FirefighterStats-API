// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="ActivityPatchUpdateDTO.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace FirefighterStats.DTO.Activity;

using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

[PublicAPI]
public class ActivityPatchUpdateDTO : IValidatableObject
{
    public DateTime EndDateTime { get; set; }

    public double? Rate { get; set; }

    public DateTime StartDateTime { get; set; }

    public string Title { get; set; } = string.Empty;

    /// <inheritdoc />
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (this.EndDateTime <= this.StartDateTime)
        {
            yield return new ValidationResult($"{nameof(this.EndDateTime)} must be after {nameof(this.StartDateTime)}", new[]
            {
                nameof(this.EndDateTime),
            });
        }
    }
}