using GameStore.Api.Dtos;

namespace GameStore.Api.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEndpointName = "GetGame";

    private static readonly List<GameDto> games = [
        new (1, "Street fighter 2", "Fighting", 19.99M, new DateOnly(1992, 7, 15)),
        new (2, "Final fantasy VII rebirth", "RPG", 69.99M, new DateOnly(2024, 2, 29)),
        new (3, "Astro bot", "Platformer", 59.99M, new DateOnly(2024, 9, 6)),
    ];

    public static void MapGamesEndpoints(this WebApplication app)
    {
        var gamesGroup = app.MapGroup("/games");

        // GET /games
        gamesGroup.MapGet("/", () => games);

        // GET /games/{id}
        gamesGroup.MapGet("/{id}", (int id) => {
            var game = games.Find(game => game.Id == id);

            return game is null ? Results.NotFound() : Results.Ok(game);
        })
            .WithName(GetGameEndpointName);

        // POST /games
        gamesGroup.MapPost("/", (CreateGameDto newGame) =>
        {
            GameDto game = new (
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
            );

            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.Id}, game);
        });

        // PUT /games/{id}
        gamesGroup.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            games[index] = new GameDto(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.ReleaseDate
            );

            return Results.NoContent();
        });

        // DELETE /games/{id}
        gamesGroup.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });
    }
}
