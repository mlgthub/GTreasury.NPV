using GTreasure.NPV.Service.Calculator;
using GTreasury.NPV.API.AutoMapper;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var allowAll = "_allowAll";

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<INPVCalculator, NPVCalculator>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowAll,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseCors(allowAll);

app.UseAuthorization();

app.MapControllers();

app.Run();
