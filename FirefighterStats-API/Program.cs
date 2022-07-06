// -----------------------------------------------------------------------
//  <copyright project="FirefighterStats-API" file="Program.cs" company="syuko">
//  Copyright (c) syuko. All rights reserved.
//  </copyright>
// -----------------------------------------------------------------------

namespace FirefighterStats;

using System.Text.Json.Serialization;
using FirefighterStats.Data;
using Microsoft.EntityFrameworkCore;

public static class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        if (builder.Environment.IsDevelopment())
        {
            _ = builder.Services.AddDbContext<ApplicationDbContext>(static options => options.UseInMemoryDatabase("FirefighterStats"));
        }

        _ = builder.Services.AddAutoMapper(typeof(Program));

        builder.Services.AddControllers().AddJsonOptions(static c => c.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        _ = builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        _ = builder.Services.AddEndpointsApiExplorer();
        _ = builder.Services.AddSwaggerGen();

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            _ = app.UseSwagger();
            _ = app.UseSwaggerUI();
        }

        _ = app.UseHttpsRedirection();

        _ = app.UseAuthorization();

        _ = app.MapControllers();

        app.Run();
    }
}