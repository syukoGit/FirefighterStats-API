// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="EActivityType.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace FirefighterStats.Utils;

using JetBrains.Annotations;

[PublicAPI]
public enum EActivityType
{
    PersonalAssistance,

    Fire,

    // Accident on Public Road
    Apr,

    FireAndApr,

    FirefighterActivity,
}