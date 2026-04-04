using System.ComponentModel.DataAnnotations;
using CobbleCompendium.Server.Utils;

namespace CobbleCompendium.Server.Database.Tables;

public class Cobblemon{
    [Key]
    public int Id { get; set; }
    public int PokedexNumber { get; set; }
    public required string Name { get; set; }
    public required Type PrimaryType { get; set; }
    public Type? SecondaryType { get; set; }
    public int MaleRation { get; set; }

    // Stats
    public int Hp { get; set; }
    public int Attack { get; set; }
    public int Defence { get; set; }
    public int SpecialAttack { get; set; }
    public int SpecialDefence { get; set; }
    public int Speed { get; set; }
}
