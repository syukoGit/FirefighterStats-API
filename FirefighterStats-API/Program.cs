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
            builder.Services.AddDbContext<ApplicationDbContext>(static options => options.UseInMemoryDatabase("FirefighterStats"));
        }

        builder.Services.AddAutoMapper(typeof(Program));

        builder.Services.AddControllers().AddJsonOptions(static c => c.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())).AddNewtonsoftJson();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        WebApplication app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}