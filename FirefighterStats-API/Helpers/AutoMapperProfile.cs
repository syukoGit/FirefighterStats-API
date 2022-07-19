// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="AutoMapperProfile.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace FirefighterStats.Helpers;

using AutoMapper;
using FirefighterStats.DTO.Activity;
using FirefighterStats.DTO.PaySlip;
using FirefighterStats.DTO.PaySlipLine;
using FirefighterStats.Entities;
using FirefighterStats.Entities.Activities;

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

        this.CreateMap<Intervention, ActivityDTO>();
        this.CreateMap<FirefighterActivity, ActivityDTO>();
        this.CreateMap<ActivityCreateDTO, Intervention>().ReverseMap();
        this.CreateMap<ActivityCreateDTO, FirefighterActivity>().ReverseMap();
        this.CreateMap<ActivityUpdateDTO, Intervention>().ReverseMap();
        this.CreateMap<ActivityUpdateDTO, FirefighterActivity>().ReverseMap();
    }
}