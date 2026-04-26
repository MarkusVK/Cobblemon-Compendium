using CobbleCompendium.Server.Models.Items;
using CobbleCompendium.Server.Utils;
using CobbleCompendium.Server.Models.DTOs;
using CobbleCompendium.Server.Models.Assemblers;

namespace CobbleCompendium.Server.Models.Seeders;

public class CobblemonSeeder(CobblemonContext _context, JsonFileReader jsonFileReader) : ISeederStrategy{
    private readonly CobblemonAssembler assembler = new();
    public async Task SeedData(){
        if(_context.Cobblemons.Any())
            return;

        List<Cobblemon> cobblemons = [];

        string speciesPath = Path.Combine("..", "Data", "cobblemon", "species");
        DirectoryInfo speciesFolder = new(speciesPath);
        foreach(DirectoryInfo genfolder in speciesFolder.GetDirectories()){
            var genFiles = Directory.EnumerateFiles(
                    genfolder.FullName, "*.json", 
                    SearchOption.TopDirectoryOnly
                    );
            foreach (string entry in genFiles)
            {
                CobblemonDTO cobblemonDTO = await jsonFileReader.ReadJson<CobblemonDTO>(entry);
                Cobblemon cobblemon = assembler.CreateCobblemon(cobblemonDTO);
                cobblemons.Add(cobblemon);
            }
        }
        _context.AddRange(cobblemons);
        await _context.SaveChangesAsync();
    }
}
