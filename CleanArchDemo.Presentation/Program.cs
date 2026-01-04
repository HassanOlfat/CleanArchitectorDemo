
using CleanArchDemo.Application.Configuration;
using CleanArchDemo.Infrastructure.Configuration;
using CleanArchDemo.Presentation.Configuration;

var builder = WebApplication.CreateBuilder(args);


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
