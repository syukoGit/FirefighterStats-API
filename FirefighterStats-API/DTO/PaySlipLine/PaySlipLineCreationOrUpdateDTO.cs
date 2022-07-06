// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="PaySlipLineCreationOrUpdateDTO.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace FirefighterStats.DTO.PaySlipLine;

using System.ComponentModel.DataAnnotations;
using JetBrains.Annotations;

[PublicAPI]
public class PaySlipLineCreationOrUpdateDTO : IValidatableObject
{
    [Required]
    [DataType(DataType.DateTime)]
    public DateTime EndDateTime { get; set; }

    [Required]
    [DataType(DataType.DateTime)]
    public DateTime StartDateTime { get; set; }

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