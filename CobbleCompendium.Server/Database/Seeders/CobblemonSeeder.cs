using CobbleCompendium.Server.Models;
using CobbleCompendium.Server.Database.Tables;
using CobbleCompendium.Server.Utils;

namespace CobbleCompendium.Server.Database.Seeders;

public class CobblemonSeeder(CobblemonContext _context, JsonFileReader jsonFileReader) : ISeederStrategy{
    public async Task SeedData(){
        if(_context.CobblemonItems.Any())
            return;

        List<Cobblemon> cobblemons = [];

        string speciesPath = Path.Combine("..", "..", "..", "Data", "cobblemon", "species");
        DirectoryInfo speciesFolder = new(speciesPath);
        foreach(DirectoryInfo genfolder in speciesFolder.GetDirectories()){
            Generations generation = FolderToGeneration(genfolder.Name);
            var genFiles = Directory.EnumerateFiles(
                    genfolder.FullName, "*.json", 
                    SearchOption.TopDirectoryOnly
                    );
            foreach (string entry in genFiles)
            {
                Cobblemon cobblemon = 
                
            }

        }

    }

    private static Generations FolderToGeneration(string folderName) => folderName switch
    {
        "generation1" => Generations.Gen1,
        "generation2" => Generations.Gen2,
        "generation3" => Generations.Gen3,
        "generation4" => Generations.Gen4,
        "generation5" => Generations.Gen5,
        "generation6" => Generations.Gen6,
        "generation7" => Generations.Gen7,
        "generation7b" => Generations.Gen7,
        "generation8" => Generations.Gen8,
        "generation8a" => Generations.Gen8,
        "generation9" => Generations.Gen9,
        _ => Generations.Unofficial,
    };
    
}
