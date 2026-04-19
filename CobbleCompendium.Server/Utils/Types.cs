namespace CobbleCompendium.Server.Utils;

public class PokemonTypeConverter{
    public Types StringToType(string type){
        return type.ToLower() switch 
        {
            "normal" => Types.Normal,
            "fire" => Types.Fire,
            "water" => Types.Water,
            "electric" => Types.Electric,
            "grass" => Types.Grass,
            "ice" => Types.Ice,
            "fighting" => Types.Fighting,
            "poison" => Types.Poison,
            "ground" => Types.Ground,
            "flying" => Types.Flying,
            "psychic" => Types.Psychic,
            "bug" => Types.Bug,
            "rock" => Types.Rock,
            "ghost" => Types.Ghost,
            "dragon" => Types.Dragon,
            "dark" => Types.Dark,
            "steel" => Types.Steel,
            "fairy" => Types.Fairy,
            "stellar" => Types.Stellar,
            _ => throw new Exception($"Recieved unkown type {type}")
        };
    }
}

public enum Types{
    Normal,
    Fire,
    Water,
    Electric,
    Grass,
    Ice,
    Fighting,
    Poison,
    Ground,
    Flying,
    Psychic,
    Bug,
    Rock,
    Ghost,
    Dragon,
    Dark,
    Steel,
    Fairy,
    Stellar
}
