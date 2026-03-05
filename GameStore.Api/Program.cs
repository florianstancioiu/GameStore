using GameStore.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

var app = builder.Build();

app.MapGet("/", () => "The GameStore.Api is up and running");
app.MapGamesEndpoints();

app.Run();
