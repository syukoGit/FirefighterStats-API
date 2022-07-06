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
    public async Task<ActionResult<List<PaySlipDTO>>> Get()
    {
        List<PaySlip> paySlips = await this.context.PaySlips.AsNoTracking().ToListAsync();

        return this.mapper.Map<List<PaySlipDTO>>(paySlips);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<PaySlipDTO>> Get(int id)
    {
        PaySlip? paySlip = await this.context.PaySlips.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

        return paySlip == null
                   ? this.NotFound()
                   : this.mapper.Map<PaySlipDTO>(paySlip);
    }

    [HttpPost]
    public async Task<ActionResult<PaySlipDTO>> Create([FromBody] PaySlipCreateOrUpdateDTO paySlipCreate)
    {
        var paySlip = this.mapper.Map<PaySlip>(paySlipCreate);

        this.context.PaySlips.Add(paySlip);
        await this.context.SaveChangesAsync();

        return this.CreatedAtAction("Get", new
        {
            paySlip.Id,
        }, this.mapper.Map<PaySlipDTO>(paySlip));
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<PaySlipDTO>> Update(int id, [FromBody] PaySlipCreateOrUpdateDTO paySlipUpdate)
    {
        if (!await this.context.PaySlips.AsNoTracking().AnyAsync(c => c.Id == id))
        {
            return this.NotFound();
        }

        var paySlip = this.mapper.Map<PaySlip>(paySlipUpdate);
        paySlip.Id = id;

        this.context.Entry(paySlip).State = EntityState.Modified;

        await this.context.SaveChangesAsync();

        var paySlipDTO = this.mapper.Map<PaySlipDTO>(paySlip);

        return this.CreatedAtAction("Get", new
        {
            id,
        }, paySlipDTO);
    }
}