namespace GameStore.Api.Dtos;

// A DTO is a contract between the client and server
// it represents how the data will be transferred and used

public record GameSummaryDto(
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);
