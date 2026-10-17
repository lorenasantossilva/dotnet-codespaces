using NotasApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Configuração do CORS para permitir requisições externas (CodePen)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

// Injeção de Dependência (Singleton para manter a lista em memória durante a execução)
builder.Services.AddSingleton<INotaFiscalService, NotaFiscalService>();

var app = builder.Build();

app.UseCors("AllowAll");
app.MapControllers();

app.Run();