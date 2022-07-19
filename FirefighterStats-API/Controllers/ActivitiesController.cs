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
using Microsoft.AspNetCore.JsonPatch;
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

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ActivityDTO>> Put(int id, [FromBody] ActivityUpdateDTO activityUpdate)
    {
        Activity? activityFromDb = await this.context.Activities.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);

        if (activityFromDb == null)
        {
            return this.NotFound();
        }

        Activity activity = activityFromDb.ActivityType == EActivityType.FirefighterActivity
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

    [HttpPatch("{id:int}")]
    public async Task<ActionResult<ActivityDTO>> Patch(int id, [FromBody] JsonPatchDocument<ActivityPatchUpdateDTO>? patchDocument)
    {
        if (patchDocument == null)
        {
            return this.BadRequest();
        }

        Activity? activityFromDb = await this.context.Activities.FirstOrDefaultAsync(c => c.Id == id);

        if (activityFromDb == null)
        {
            return this.NotFound();
        }

        var activityDTO = this.mapper.Map<ActivityPatchUpdateDTO>(activityFromDb);

        patchDocument.ApplyTo(activityDTO, this.ModelState);

        if (!this.TryValidateModel(activityDTO))
        {
            return this.BadRequest(this.ModelState);
        }

        this.mapper.Map(activityDTO, activityFromDb);

        await this.context.SaveChangesAsync();

        return this.CreatedAtAction("Get", new
        {
            activityFromDb.Id,
        }, this.mapper.Map<ActivityDTO>(activityFromDb));
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        Activity? activity = await this.context.Activities.FirstOrDefaultAsync(x => x.Id == id);

        if (activity == null)
        {
            return this.NotFound();
        }

        this.context.Remove(activity);

        await this.context.SaveChangesAsync();

        return this.Ok();
    }
}