using Microsoft.EntityFrameworkCore;
using src.Adaptadores;
using src.Nucleo.Controllers;
using src.Nucleo.Repositorios;
using src.Nucleo.IServicos;
using src.Nucleo.Servicos;
using src.Portas;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<BDAdapter>(options =>
    options.UseSqlite("Data Source=biblioteca.db"));
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

builder.Services.AddScoped<BDPort>(provider =>
    provider.GetRequiredService<BDAdapter>());
builder.Services.AddControllers();
builder.Services.AddCors(options => 
    options.AddPolicy("AllowAllOrigins", 
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        }
    )
);

// Repositórios
builder.Services.AddScoped<LivroRepository>();
builder.Services.AddScoped<EstudanteRepository>();
builder.Services.AddScoped<ReservaRepository>();

// Serviços do núcleo
builder.Services.AddScoped<ILivroService, LivroService>();
builder.Services.AddScoped<IEstudanteService, EstudanteService>();
builder.Services.AddScoped<IReservaService, ReservaService>();
builder.Services.AddScoped<INotificacaoService, NotificacaoService>();

// Adaptador de notificação
builder.Services.AddScoped<NotificadorPort, NotificadorEmailAdapter>();

// Controllers do núcleo
builder.Services.AddScoped<LivroController>();
builder.Services.AddScoped<ReservaController>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();