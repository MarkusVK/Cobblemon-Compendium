using System.Text.Json;
using CobbleCompendium.Server.Models;

namespace CobbleCompendium.Server.Utils;

public class JsonFileReader
{
    private const string folderPath = "../Cobblemon/generation1";
    public CobblemonItem GetCobblemon(string fileName){
        string filePath = $"{folderPath}/{fileName}.json";
        string jsonString = File.ReadAllText(filePath);
        CobblemonItem cobblemonItem = JsonSerializer.Deserialize<CobblemonItem>(jsonString)!;
        return cobblemonItem;
    }
}
