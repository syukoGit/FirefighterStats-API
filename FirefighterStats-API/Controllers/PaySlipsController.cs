// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="PaySlipsController.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace FirefighterStats.Controllers;

using AutoMapper;
using FirefighterStats.Data;
using FirefighterStats.DTO.PaySlip;
using FirefighterStats.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class PaySlipsController : ControllerBase
{
    private readonly ApplicationDbContext context;

    private readonly IMapper mapper;

    public PaySlipsController(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<PaySlipDTO>>> GetPayslips()
    {
        List<PaySlip> paySlips = await this.context.PaySlips.AsNoTracking().ToListAsync();

        return this.mapper.Map<List<PaySlipDTO>>(paySlips);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PaySlipDTO>> GetPaySlip(int id)
    {
        PaySlip? paySlip = await this.context.PaySlips.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

        return paySlip == null
                   ? this.NotFound()
                   : this.mapper.Map<PaySlipDTO>(paySlip);
    }
}