using GameStore.Api.Data;
using GameStore.Api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;

public static class GenresEndpoints
{
    public static void MapGenresEndpoints(this WebApplication app)
    {
        var genreGroup = app.MapGroup("/genres");

        // GET /genres
        genreGroup.MapGet("/", async (GameStoreContext dbContext) => await dbContext.Genres
                .Select(genre => new GenreDto(genre.Id, genre.Name))
                .AsNoTracking() // the entities retrieved from the db don't need to be updated
                .ToListAsync() // make the select async
        );
    }
}