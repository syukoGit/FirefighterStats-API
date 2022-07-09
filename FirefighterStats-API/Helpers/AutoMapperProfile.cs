﻿// -----------------------------------------------------------------------
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
        this.CreateMap<PaySlipCreateOrUpdateDTO, PaySlip>();
        this.CreateMap<PaySlipPatchUpdateDTO, PaySlip>().ReverseMap();

        this.CreateMap<PaySlipLine, PaySlipLineDTO>();
        this.CreateMap<PaySlipLineCreationOrUpdateDTO, PaySlipLine>();
        this.CreateMap<PaySlipLinePatchUpdateDTO, PaySlipLine>().ReverseMap();
    }
}