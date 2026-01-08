
using CleanArchDemo.Application.Configuration;
using CleanArchDemo.Infrastructure.Dependencies.Configuration;
using CleanArchDemo.Infrastructure.Persistence;
using CleanArchDemo.Presentation.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
//fortest
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("TestDb"));



builder.Services.AddInfrastructure();
builder.Services.AddApplication();
builder.Services.AddPresentation();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
