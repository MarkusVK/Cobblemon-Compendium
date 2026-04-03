
namespace CobbleCompendium.Server.Models;

public class CobblemonItem
{
    public long Id { get; set; }
    public int nationalPokedexNumber { get; set; }
    public string? name { get; set; }
    public string? primaryType { get; set; } 
    public string? secondaryType { get; set; }
}
