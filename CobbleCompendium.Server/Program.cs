using Microsoft.EntityFrameworkCore;
using CobbleCompendium.Server.Models;
using CobbleCompendium.Server.Utils;
using CobbleCompendium.Server.Database.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add CORS so React can be used
builder.Services.AddCors(options => 
{
    options.AddPolicy("AllowAngularApp", builder => 
    {
        builder.WithOrigins("https://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<CobblemonContext>(options =>
        options.UseSqlite("Data Source=./Database/CobblemonCompendium.db"));

builder.Services.AddScoped<JsonFileReader>();
builder.Services.AddScoped<DataSeeder>();

var app = builder.Build();

using (var scope = app.Services.CreateScope()){
    var dbContext = scope.ServiceProvider.GetRequiredService<CobblemonContext>();
    var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();

    await seeder.SeedAsync();
}


// Configure the HTTP request pipeline.
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
