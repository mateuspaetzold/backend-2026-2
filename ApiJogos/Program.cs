using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "API do Catálogo de Jogos está no ar!");

app.MapGet("/api/jogos", () =>
{
    return Results.Ok(new[]
    {
        new { id = 1, titulo = "Fortnite", disponivel = true },
        new { id = 2, titulo = "Minecraft", disponivel = false }
    });
});

app.MapGet("/api/jogos/{id:int}", (int id) =>
{
    if (id == 1) return Results.Ok(new { id = 1, titulo = "Fortnite", disponivel = true });
    if (id == 2) return Results.Ok(new { id = 2, titulo = "Minecraft", disponivel = false });
    return Results.NotFound(new { mensagem = "Jogo não encontrado." });
});

app.MapPost("/api/jogos", async (HttpRequest requisicao) =>
{
    using JsonDocument documento = await JsonDocument.ParseAsync(requisicao.Body);
    string titulo = documento.RootElement.GetProperty("titulo").GetString() ?? "";
    return Results.Created("/api/jogos/3", new { id = 3, titulo, disponivel = true });
});

app.MapPut("/api/jogos/{id:int}", async (int id, HttpRequest requisicao) =>
{
    if (id != 1 && id != 2) return Results.NotFound(new { mensagem = "Jogo não encontrado." });
    using JsonDocument documento = await JsonDocument.ParseAsync(requisicao.Body);
    string titulo = documento.RootElement.GetProperty("titulo").GetString() ?? "";
    return Results.Ok(new { id, titulo, disponivel = true, mensagem = "Jogo atualizado." });
});

app.MapDelete("/api/jogos/{id:int}", (int id) =>
{
    if (id != 1 && id != 2) return Results.NotFound(new { mensagem = "Jogo não encontrado." });
    return Results.NoContent();
});

app.Run();