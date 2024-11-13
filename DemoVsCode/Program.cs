using DemoVsCode;
using Serilog;


//Configuração Builder
var builder = WebApplication.CreateBuilder(args);

//Configuração do Pipeline

//Middlewares
builder.AddSerilog();
//Services

//Configuraçãoo da App
var app = builder.Build();

app.UseLogTempo();

app.MapGet("/", () => "Hello World!");

app.MapGet("/teste", () =>
{
    Thread.Sleep(1500);
    return "Teste 2";
});

app.Run();
