// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="ActivitiesController.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace FirefighterStats.Controllers;

using AutoMapper;
using FirefighterStats.Data;
using FirefighterStats.DTO.Activity;
using FirefighterStats.Entities;
using FirefighterStats.Entities.Activities;
using FirefighterStats.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ActivitiesController : ControllerBase
{
    private readonly ApplicationDbContext context;

    private readonly IMapper mapper;

    public ActivitiesController(ApplicationDbContext context, IMapper mapper)
    {
        this.context = context;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<List<ActivityDTO>>> Get()
    {
        List<Activity> activities = await this.context.Activities.AsNoTracking().ToListAsync();

        return this.mapper.Map<List<ActivityDTO>>(activities);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ActivityDTO>> Get(int id)
    {
        Activity? activity = await this.context.Activities.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

        return activity == null
                   ? this.NotFound()
                   : this.mapper.Map<ActivityDTO>(activity);
    }

    [HttpPost]
    public async Task<ActionResult<ActivityDTO>> Post([FromBody] ActivityCreateDTO activityCreate)
    {
        Activity activity = activityCreate.ActivityType == EActivityType.FirefighterActivity
                                ? this.mapper.Map<FirefighterActivity>(activityCreate)
                                : this.mapper.Map<Intervention>(activityCreate);

        this.context.Activities.Add(activity);
        await this.context.SaveChangesAsync();

        return this.CreatedAtAction("Get", new
        {
            activity.Id,
        }, this.mapper.Map<ActivityDTO>(activity));
    }

    [HttpPut]
    public async Task<ActionResult<ActivityDTO>> Put(int id, [FromBody] ActivityUpdateDTO activityUpdate)
    {
        Activity? activityInDb = await this.context.Activities.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

        if (activityInDb == null)
        {
            return this.NotFound();
        }

        Activity activity = activityInDb.ActivityType == EActivityType.FirefighterActivity
                                ? this.mapper.Map<FirefighterActivity>(activityUpdate)
                                : this.mapper.Map<Intervention>(activityUpdate);

        activity.Id = id;

        this.context.Entry(activity).State = EntityState.Modified;

        await this.context.SaveChangesAsync();

        var activityDTO = this.mapper.Map<ActivityDTO>(activity);

        return this.CreatedAtAction("Get", new
        {
            id,
        }, activityDTO);
    }
}