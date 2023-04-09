using DrillingSupportWebApi.Abstractions;
using DrillingSupportWebApi.DataAccess;
using DrillingSupportWebApi.Domain.DrillBlockPointsPointss.Services;
using DrillingSupportWebApi.Domain.DrillBlocks.Services;
using DrillingSupportWebApi.Domain.HolePointsss.Services;
using DrillingSupportWebApi.Domain.Holes.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(
    x => x.UseNpgsql(builder.Configuration.GetConnectionString("DrillingSupportDbConnection")));

builder.Services.AddControllers();
builder.Services.AddTransient<IDataStore, EfDataStore>();
builder.Services.AddTransient<DrillBlockService>();
builder.Services.AddTransient<DrillBlockPointsService>();
builder.Services.AddTransient<HolePointsService>();
builder.Services.AddTransient<HoleService>();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
