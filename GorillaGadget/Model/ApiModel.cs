using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace GorillaGadget.Model
{
    public record Match(
    [property: JsonPropertyName("id")] string Id,
    [property: JsonPropertyName("end_time")] DateTime EndTime,
    [property: JsonPropertyName("worlds")] Worlds Worlds,
    [property: JsonPropertyName("all_worlds")] AllWorlds AllWorlds,
    [property: JsonPropertyName("victory_points")] VictoryPoints VictoryPoints,
    [property: JsonPropertyName("skirmishes")] IReadOnlyList<Skirmish> Skirmishes
    );

    public record World(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("population")] string Population
    );

    public record Worlds(
        [property: JsonPropertyName("red")] int Red,
        [property: JsonPropertyName("blue")] int Blue,
        [property: JsonPropertyName("green")] int Green
    );

    public record AllWorlds(
        [property: JsonPropertyName("red")] IReadOnlyList<int> Red,
        [property: JsonPropertyName("blue")] IReadOnlyList<int> Blue,
        [property: JsonPropertyName("green")] IReadOnlyList<int> Green
    );

    public record VictoryPoints(
        [property: JsonPropertyName("red")] int Red,
        [property: JsonPropertyName("blue")] int Blue,
        [property: JsonPropertyName("green")] int Green
    );

    public record Skirmish(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("scores")] Scores Scores
    );

    public record Scores(
        [property: JsonPropertyName("red")] int Red,
        [property: JsonPropertyName("blue")] int Blue,
        [property: JsonPropertyName("green")] int Green
    );

    public record Exchange(
        [property: JsonPropertyName("coins_per_gem")] decimal Coins
    );
}