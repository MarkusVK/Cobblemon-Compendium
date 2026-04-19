using CobbleCompendium.Server.Models.DTOs;
using CobbleCompendium.Server.Database.Tables;
using CobbleCompendium.Server.Utils;

namespace CobbleCompendium.Server.Models.Assemblers;

public class CobblemonAssembler{
    private readonly PokemonTypeConverter typeConverter = new();

    public Cobblemon CreateCobblemon(CobblemonDTO cobblemonDTO){
        Stats stats = cobblemonDTO.BaseStats;
        Types primaryType = typeConverter.StringToType(cobblemonDTO.PrimaryType);
        Types? secondaryType = cobblemonDTO.SecondaryType is null ? typeConverter.StringToType(cobblemonDTO.PrimaryType) : null;
        Generations generation = GetGeneration(cobblemonDTO.Labels);

        Cobblemon result = new()
        {
            PokedexNumber = cobblemonDTO.NationalPokedexNumber,
            Generation = generation,
            Name = cobblemonDTO.Name,
            PrimaryType = primaryType,
            SecondaryType = secondaryType,
            MaleRatio = (int)(cobblemonDTO.MaleRatio * 100),
            Hp = stats.Hp,
            Attack = stats.Attack,
            Defence = stats.Defence,
            SpecialAttack = stats.Special_attack,
            SpecialDefence = stats.Special_defence,
            Speed = stats.Speed
        };

        return result;
    }

    private static Generations GetGeneration(string[] labels){
        foreach (string label in labels){
            switch (label)
            {
                case "gen1": 
                    return Generations.Gen1;
                case "gen2": 
                    return Generations.Gen2;
                case "gen3": 
                    return Generations.Gen3;
                case "gen4": 
                    return Generations.Gen4;
                case "gen5": 
                    return Generations.Gen5;
                case "gen6": 
                    return Generations.Gen6;
                case "gen7": 
                    return Generations.Gen7;
                case "gen8": 
                    return Generations.Gen8;
                case "gen9": 
                    return Generations.Gen9;
            }
        }
        throw new Exception($"Couldn't find generation in {labels}");
    }
}
