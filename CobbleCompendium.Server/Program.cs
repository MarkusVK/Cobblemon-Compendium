using Microsoft.EntityFrameworkCore;
using CobbleCompendium.Server.Models;

var builder = WebApplication.CreateBuilder(args);

// Add CORS so React can be used
builder.Services.AddCors(options => 
{
    options.AddPolicy("AllowReact", builder => 
    {
        builder.WithOrigins("https://localhost:5001")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<TestContext>(options =>
        options.UseInMemoryDatabase("TestList"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUi(options =>
    {
        options.DocumentPath = "/openapi/v1.json";
    });
}

app.UseCors("AllowReactApp");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
