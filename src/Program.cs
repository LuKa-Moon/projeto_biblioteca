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

System.OverflowException: Arithmetic operation resulted in an overflow.
   at Microsoft.Data.Sqlite.SqliteValueReader.GetInt32(Int32 ordinal)
   at Microsoft.Data.Sqlite.SqliteDataReader.GetInt32(Int32 ordinal)
   at lambda_method163(Closure, QueryContext, DbDataReader, ResultContext, SingleQueryResultCoordinator)
   at Microsoft.EntityFrameworkCore.Query.Internal.SingleQueryingEnumerable`1.AsyncEnumerator.MoveNextAsync()
   at Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync[TSource](IQueryable`1 source, CancellationToken cancellationToken)
   at Microsoft.EntityFrameworkCore.EntityFrameworkQueryableExtensions.ToListAsync[TSource](IQueryable`1 source, CancellationToken cancellationToken)
   at src.Adaptadores.BDAdapter.GetComRelacionamentos[T](Object id) in /home/gustavo/Documentos/projeto_biblioteca/src/Adaptadores/BDAdapter.cs:line 41
   at src.Nucleo.Repositorios.EstudanteRepository.Get(Object id) in /home/gustavo/Documentos/projeto_biblioteca/src/Nucleo/Repositorios/EstudanteRepository.cs:line 20
   at src.Nucleo.Controllers.ReservaController.ReservarLivro(String grr, String idLivro) in /home/gustavo/Documentos/projeto_biblioteca/src/Nucleo/Controllers/ReservaController.cs:line 42
   at src.Adaptadores.WebAdapter.ReservarLivro(String grr, String idLivro) in /home/gustavo/Documentos/projeto_biblioteca/src/Adaptadores/WebAdapter.cs:line 44
   at lambda_method115(Closure, Object)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ActionMethodExecutor.AwaitableObjectResultExecutor.Execute(ActionContext actionContext, IActionResultTypeMapper mapper, ObjectMethodExecutor executor, Object controller, Object[] arguments)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeActionMethodAsync>g__Awaited|12_0(ControllerActionInvoker invoker, ValueTask`1 actionResultValueTask)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.<InvokeNextActionFilterAsync>g__Awaited|10_0(ControllerActionInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Rethrow(ActionExecutedContextSealed context)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.Next(State& next, Scope& scope, Object& state, Boolean& isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ControllerActionInvoker.InvokeInnerFilterAsync()
--- End of stack trace from previous location ---
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeFilterPipelineAsync>g__Awaited|20_0(ResourceInvoker invoker, Task lastTask, State next, Scope scope, Object state, Boolean isCompleted)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
   at Microsoft.AspNetCore.Mvc.Infrastructure.ResourceInvoker.<InvokeAsync>g__Awaited|17_0(ResourceInvoker invoker, Task task, IDisposable scope)
   at Microsoft.AspNetCore.Authorization.AuthorizationMiddleware.Invoke(HttpContext context)
   at Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddlewareImpl.Invoke(HttpContext context)

HEADERS
=======
Accept: */*
Connection: keep-alive
Host: localhost:5086
User-Agent: Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/148.0.0.0 Mobile Safari/537.36
Accept-Encoding: gzip, deflate, br, zstd
Accept-Language: pt-BR,pt;q=0.9,en-US;q=0.8,en;q=0.7
Origin: http://127.0.0.1:5501
Referer: http://127.0.0.1:5501/
Content-Length: 0
sec-ch-ua-platform: "Android"
sec-ch-ua: "Chromium";v="148", "Google Chrome";v="148", "Not/A)Brand";v="99"
sec-ch-ua-mobile: ?1
Sec-Fetch-Site: cross-site
Sec-Fetch-Mode: cors
Sec-Fetch-Dest: empty