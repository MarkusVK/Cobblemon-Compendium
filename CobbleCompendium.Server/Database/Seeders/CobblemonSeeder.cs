using CobbleCompendium.Server.Models;
using CobbleCompendium.Server.Database.Tables;
using CobbleCompendium.Server.Utils;
using CobbleCompendium.Server.Models.DTOs;
using CobbleCompendium.Server.Models.Assemblers;

namespace CobbleCompendium.Server.Database.Seeders;

public class CobblemonSeeder(CobblemonContext _context, JsonFileReader jsonFileReader) : ISeederStrategy{
    private readonly CobblemonAssembler assembler = new();
    public async Task SeedData(){
        if(_context.CobblemonItems.Any())
            return;

        string speciesPath = Path.Combine("..", "..", "..", "Data", "cobblemon", "species");
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
                _context.Add(cobblemon);
            }
        }
        await _context.SaveChangesAsync();
    }
}
