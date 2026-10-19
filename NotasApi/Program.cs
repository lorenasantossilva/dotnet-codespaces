using NotasApi.Services;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddSingleton<INotaFiscalService, NotaFiscalService>();

var app = builder.Build();

app.UseCors("AllowAll");
app.MapControllers();

app.Run();