// Exercício 1
string nome = "Ana";
int idade = 20;
double altura = 1.68;
decimal saldo = 250.00m;
bool matriculada = true;
char turma = 'B';

var cidade = "Canoas";
const double PI = 3.14159;

Console.WriteLine($"Nome: {nome}");
Console.WriteLine($"Idade: {idade} anos");
Console.WriteLine($"Altura: {altura} m");
Console.WriteLine($"Saldo: R$ {saldo}");
Console.WriteLine($"Matriculada: {matriculada}");
Console.WriteLine($"Turma: {turma}");
Console.WriteLine($"Cidade: {cidade}");
Console.WriteLine($"PI: {PI}");

// Exercício 2
Console.Write("Seu nome: ");
string? nome2 = Console.ReadLine();

Console.Write("Sua idade: ");
string? entradaIdade = Console.ReadLine();
int idade2 = Convert.ToInt32(entradaIdade);

Console.WriteLine($"Oi, {nome2}! Daqui a 10 anos você terá {idade2 + 10} anos.");

// Exercício 3
Console.Write("Valor da compra: R$ ");
string? entrada = Console.ReadLine();
decimal subtotal = Convert.ToDecimal(entrada);

decimal desconto = 0m;

if (subtotal >= 500m)
{
    desconto = 0.20m;
}
else if (subtotal >= 200m)
{
    desconto = 0.10m;
}
else if (subtotal >= 100m)
{
    desconto = 0.05m;
}

decimal total = subtotal - (subtotal * desconto);

Console.WriteLine($"Desconto aplicado: {desconto:P0}");
Console.WriteLine($"Total a pagar: R$ {total:F2}");