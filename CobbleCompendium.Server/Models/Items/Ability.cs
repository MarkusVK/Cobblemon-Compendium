using System.ComponentModel.DataAnnotations;

namespace CobbleCompendium.Server.Models.Items;

public class Ability{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
}
