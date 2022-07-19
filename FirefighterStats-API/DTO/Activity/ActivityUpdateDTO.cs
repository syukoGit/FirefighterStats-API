// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="ActivityUpdateDTO.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace FirefighterStats.DTO.Activity;

using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

[PublicAPI]
public class ActivityUpdateDTO : IValidatableObject
{
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
        if (this.EndDateTime <= this.StartDateTime)
        {
            yield return new ValidationResult($"{nameof(this.EndDateTime)} must be after {nameof(this.StartDateTime)}", new[]
            {
                nameof(this.EndDateTime),
            });
        }
    }
}