using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var jogos = new List<Jogo>
{
    new Jogo(1, "Fortnite", true),
    new Jogo(2, "Minecraft", false)
};

app.MapGet("/", () => "API do Catálogo de Jogos está no ar!");

app.MapGet("/api/jogos", () =>
{
    return Results.Ok(jogos);
});

app.MapGet("/api/jogos/{id}", (int id) =>
{
    var jogoEncontrado = jogos.Find(jogo => jogo.Id == id);
    if (jogoEncontrado is null)
    {
        return Results.NotFound();
    }
    return Results.Ok(jogoEncontrado);
});

app.MapPost("/api/jogos", (JogoEntradaDto dados) =>
{
    int proximoId = jogos.Count + 1;
    var novoJogo = new Jogo(proximoId, dados.Titulo, true);
    jogos.Add(novoJogo);
    return Results.Created($"/api/jogos/{novoJogo.Id}", novoJogo);
});

app.Run();

record Jogo(int Id, string Titulo, bool Disponivel);
record JogoEntradaDto(string Titulo);