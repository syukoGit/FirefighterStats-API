// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="AutoMapperProfile.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace FirefighterStats.Helpers;

using AutoMapper;
using FirefighterStats.DTO.PaySlip;
using FirefighterStats.DTO.PaySlipLine;
using FirefighterStats.Entities;

// ReSharper disable once UnusedType.Global
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        _ = this.CreateMap<PaySlip, PaySlipDTO>();

        _ = this.CreateMap<PaySlipLine, PaySlipLineDTO>();
    }
}