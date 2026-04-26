using System.ComponentModel.DataAnnotations;
using CobbleCompendium.Server.Utils;

namespace CobbleCompendium.Server.Models.Items;

public class Cobblemon{
    [Key]
    public int Id { get; set; }
    public int PokedexNumber { get; set; }
    public Generations Generation { get; set; }
    public required string Name { get; set; }
    public Types PrimaryType { get; set; }
    public Types? SecondaryType { get; set; }
    public int MaleRatio { get; set; }

    // Stats
    public int Hp { get; set; }
    public int Attack { get; set; }
    public int Defence { get; set; }
    public int SpecialAttack { get; set; }
    public int SpecialDefence { get; set; }
    public int Speed { get; set; }
}
