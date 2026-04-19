namespace CobbleCompendium.Server.Models.DTOs;

public record CobblemonDTO(
    bool Implemented,
    int NationalPokedexNumber,
    string Name,
    string PrimaryType,
    string SecondaryType,
    float MaleRatio,
    int Height,
    int Weight,
    string[] Pokedex,
    string[] Labels,
    string[] Aspects,
    string[] Abilities,
    string[] EggGroups,
    Stats BaseStats,
    Stats EvYield,
    int BaseExperienceYield,
    string ExperienceGroup,
    int CatchRate,
    int EggCycles,
    int BaseFriendship,
    float BaseScale,
    //var Hitbox,
    //var Behaviour,
    Drops Drops,
    string[] Moves,
    string PreEvolution,
    Evolution[] Evolutions,
    CobblemonDTO Forms,
    string Riding,
    bool Rideable
);

public record Stats(
    int Hp,
    int Attack,
    int Defence,
    int Special_attack,
    int Special_defence,
    int Speed
);

public record Drops(
    int Amount,
    DropEntries[] Entries
);

public record DropEntries(
    string Item,
    string QuantityRange,
    float Percentage
);

public record Evolution(
    string Id,
    string Variant,
    string Result,
    bool ConsumeHeldItem,
    string[] LearnableMoves,
    EvolutionRequirement[] Requirements 
);

public record EvolutionRequirement(
    string Variant,
    int MinLevel
);
