// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="ActivityDTO.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace FirefighterStats.DTO.Activity;

using FirefighterStats.Utils;
using JetBrains.Annotations;
using Newtonsoft.Json;

[PublicAPI]
public class ActivityDTO
{
    public EActivityType ActivityType { get; set; }

    public DateTime EndDateTime { get; set; }

    public int Id { get; set; }

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public double? Rate { get; set; }

    public DateTime StartDateTime { get; set; }

    public string Title { get; set; } = string.Empty;
}