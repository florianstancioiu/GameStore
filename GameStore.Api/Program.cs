using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

List<GameDto> games = [
    new (1, "Street fighter 2", "Fighting", 19.99M, new DateOnly(1992, 7, 15)),
    new (2, "Final fantasy VII rebirth", "RPG", 69.99M, new DateOnly(2024, 2, 29)),
    new (3, "Astro bot", "Platformer", 59.99M, new DateOnly(2024, 9, 6)),
];

// GET /games
app.MapGet("/games", () => games);

app.Run();
