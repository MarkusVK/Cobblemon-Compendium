using CobbleCompendium.Server.Utils;

namespace CobbleCompendium.Server.Models.Items;

public class Move{ // Check if it makes sense to split this based on move category
    public int Id { get; set; }
    public required Type Type { get; set; }
    public int? Power { get; set; }
    public float? CritChance { get; set; }
    public int Accuracy { get; set; }
}
