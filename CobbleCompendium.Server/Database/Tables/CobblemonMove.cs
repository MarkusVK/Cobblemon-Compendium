using CobbleCompendium.Server.Utils;

namespace CobbleCompendium.Server.Database.Tables;

public class CobblemonMove{
    public Learnset Learnset { get; set; }
    public int CobblemonId { get; set; }
    public int MoveId { get; set; }
}
