using System.Text.Json;

namespace CobbleCompendium.Server.Utils;

public class JsonFileReader
{
    private readonly JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true};

    public async Task<List<T>> ReadJson<T>(string filePath){
        try
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File {filePath} could not be found");

            var json = await File.ReadAllTextAsync(filePath);
            var data = JsonSerializer.Deserialize<List<T>>(json, options);
            return data ?? [];
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException($"Error deserializing {filePath}: {ex.Message}", ex);
        }
    }

    public string GetCobblemon(string filePath){
        return File.ReadAllText(filePath);
    }
}
