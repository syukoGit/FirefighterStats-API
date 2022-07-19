// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="Percentage.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace FirefighterStats.Utils;

public sealed class Percentage
{
    private readonly double value;

    private Percentage(double value) => this.value = value;

    public static bool operator ==(Percentage? left, Percentage? right) => left?.Equals(right) ?? right is null;

    public static implicit operator Percentage(double value) => new (value);

    public static implicit operator double(Percentage percentage) => percentage.value;

    public static bool operator !=(Percentage? left, Percentage? right) => !(left == right);

    public static double operator *(Percentage left, double right) => right * left.value / 100;

    public static double operator *(double left, Percentage right) => left * right.value / 100;

    /// <inheritdoc />
    public override bool Equals(object? obj) => obj is Percentage other && this.Equals(other);

    /// <inheritdoc />
    public override int GetHashCode() => this.value.GetHashCode();

    private bool Equals(Percentage? other) => other != null && this.value.Equals(other.value);
}