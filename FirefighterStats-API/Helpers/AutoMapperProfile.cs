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
        this.CreateMap<PaySlip, PaySlipDTO>();
        this.CreateMap<PaySlipCreationDTO, PaySlip>();

        this.CreateMap<PaySlipLine, PaySlipLineDTO>();
        this.CreateMap<PaySlipLineCreationDTO, PaySlipLine>();
    }
}