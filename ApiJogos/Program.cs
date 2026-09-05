var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "API do Catálogo de Jogos está no ar!");

app.Run();