using CobbleCompendium.Server.Utils;

namespace CobbleCompendium.Server.Models.Seeders;

public class DataSeeder(params ISeederStrategy[] seeders)
{
    private readonly List<ISeederStrategy> _seeders = [.. seeders];

    public async Task SeedAsync(){
        foreach (var seeder in _seeders){
            await seeder.SeedData();
        }
    }
}
