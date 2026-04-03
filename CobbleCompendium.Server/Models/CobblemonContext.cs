using Microsoft.EntityFrameworkCore;

namespace CobbleCompendium.Server.Models;

public class CobblemonContext : DbContext 
{
    public CobblemonContext(DbContextOptions<CobblemonContext> options) : base(options) {}

    public DbSet<CobblemonItem> CobblemonItems { get; set; } = null!;
}
