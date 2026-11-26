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

builder.Services.AddScoped<INotificacaoService, NotificacaoService>();

builder.Services.AddScoped<ReservaController>();
builder.Services.AddScoped<LivroController>();

builder.Services.AddScoped<ReservaRepository>();
builder.Services.AddScoped<LivroRepository>();
builder.Services.AddScoped<EstudanteRepository>();

builder.Services.AddScoped<NotificadorPort, NotificadorEmailAdapter>();

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