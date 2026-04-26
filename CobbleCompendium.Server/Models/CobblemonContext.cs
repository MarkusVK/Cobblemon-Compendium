using Microsoft.EntityFrameworkCore;
using CobbleCompendium.Server.Models.Items;

namespace CobbleCompendium.Server.Models;

public class CobblemonContext(DbContextOptions<CobblemonContext> options) : DbContext(options) 
{
    private readonly string databasePath = Path.Combine("..","Database","CobblemonDatbase.db");

    public DbSet<Cobblemon> Cobblemons { get; set; } = null!;
    protected override void OnConfiguring(DbContextOptionsBuilder options) 
        => options.UseSqlite($"Data Source={databasePath}");
}
