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
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);
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

Usando as configurações de inicialização de /home/gustavo/Documentos/projeto_biblioteca/src/Properties/launchSettings.json...
Compilando...
/home/gustavo/Documentos/projeto_biblioteca/src/Nucleo/Modelos/Reserva.cs(8,16): warning CS8618: O propriedade não anulável 'LivroReservado' precisa conter um valor não nulo ao sair do construtor. Considere adicionar o modificador "obrigatório" ou declarar o propriedade como anulável.
/home/gustavo/Documentos/projeto_biblioteca/src/Nucleo/Modelos/Prazo.cs(10,16): warning CS8618: O propriedade não anulável 'Responsavel' precisa conter um valor não nulo ao sair do construtor. Considere adicionar o modificador "obrigatório" ou declarar o propriedade como anulável.
/home/gustavo/Documentos/projeto_biblioteca/src/Adaptadores/NotificadorEmailAdapter.cs(20,21): warning CS8604: Possível argumento de referência nula para o parâmetro 'address' em 'MailboxAddress.MailboxAddress(string? name, string address)'.
/home/gustavo/Documentos/projeto_biblioteca/src/Adaptadores/NotificadorEmailAdapter.cs(44,21): warning CS8604: Possível argumento de referência nula para o parâmetro 'userName' em 'Task MailService.AuthenticateAsync(string userName, string password, CancellationToken cancellationToken = default(CancellationToken))'.
/home/gustavo/Documentos/projeto_biblioteca/src/Adaptadores/NotificadorEmailAdapter.cs(45,21): warning CS8604: Possível argumento de referência nula para o parâmetro 'password' em 'Task MailService.AuthenticateAsync(string userName, string password, CancellationToken cancellationToken = default(CancellationToken))'.
Unhandled exception. System.AggregateException: Some services are not able to be constructed (Error while validating the service descriptor 'ServiceType: src.Nucleo.Controllers.ReservaController Lifetime: Scoped ImplementationType: src.Nucleo.Controllers.ReservaController': Unable to resolve service for type 'src.Portas.BDPort' while attempting to activate 'src.Nucleo.Repositorios.LivroRepository'.) (Error while validating the service descriptor 'ServiceType: src.Nucleo.Controllers.LivroController Lifetime: Scoped ImplementationType: src.Nucleo.Controllers.LivroController': Unable to resolve service for type 'src.Portas.BDPort' while attempting to activate 'src.Nucleo.Repositorios.LivroRepository'.) (Error while validating the service descriptor 'ServiceType: src.Nucleo.Repositorios.LivroRepository Lifetime: Scoped ImplementationType: src.Nucleo.Repositorios.LivroRepository': Unable to resolve service for type 'src.Portas.BDPort' while attempting to activate 'src.Nucleo.Repositorios.LivroRepository'.) (Error while validating the service descriptor 'ServiceType: src.Nucleo.Repositorios.EstudanteRepository Lifetime: Scoped ImplementationType: src.Nucleo.Repositorios.EstudanteRepository': Unable to resolve service for type 'src.Portas.BDPort' while attempting to activate 'src.Nucleo.Repositorios.EstudanteRepository'.)
 ---> System.InvalidOperationException: Error while validating the service descriptor 'ServiceType: src.Nucleo.Controllers.ReservaController Lifetime: Scoped ImplementationType: src.Nucleo.Controllers.ReservaController': Unable to resolve service for type 'src.Portas.BDPort' while attempting to activate 'src.Nucleo.Repositorios.LivroRepository'.
 ---> System.InvalidOperationException: Unable to resolve service for type 'src.Portas.BDPort' while attempting to activate 'src.Nucleo.Repositorios.LivroRepository'.
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateArgumentCallSites(ServiceIdentifier serviceIdentifier, Type implementationType, CallSiteChain callSiteChain, ParameterInfo[] parameters, Boolean throwIfCallSiteNotFound)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateConstructorCallSite(ResultCache lifetime, ServiceIdentifier serviceIdentifier, Type implementationType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateExact(ServiceDescriptor descriptor, ServiceIdentifier serviceIdentifier, CallSiteChain callSiteChain, Int32 slot)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.TryCreateExact(ServiceIdentifier serviceIdentifier, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateCallSite(ServiceIdentifier serviceIdentifier, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateArgumentCallSites(ServiceIdentifier serviceIdentifier, Type implementationType, CallSiteChain callSiteChain, ParameterInfo[] parameters, Boolean throwIfCallSiteNotFound)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateConstructorCallSite(ResultCache lifetime, ServiceIdentifier serviceIdentifier, Type implementationType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateExact(ServiceDescriptor descriptor, ServiceIdentifier serviceIdentifier, CallSiteChain callSiteChain, Int32 slot)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.GetCallSite(ServiceDescriptor serviceDescriptor, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceProvider.ValidateService(ServiceDescriptor descriptor)
   --- End of inner exception stack trace ---
   at Microsoft.Extensions.DependencyInjection.ServiceProvider.ValidateService(ServiceDescriptor descriptor)
   at Microsoft.Extensions.DependencyInjection.ServiceProvider..ctor(ICollection`1 serviceDescriptors, ServiceProviderOptions options)
   --- End of inner exception stack trace ---
   at Microsoft.Extensions.DependencyInjection.ServiceProvider..ctor(ICollection`1 serviceDescriptors, ServiceProviderOptions options)
   at Microsoft.Extensions.DependencyInjection.ServiceCollectionContainerBuilderExtensions.BuildServiceProvider(IServiceCollection services, ServiceProviderOptions options)
   at Microsoft.Extensions.Hosting.HostApplicationBuilder.Build()
   at Microsoft.AspNetCore.Builder.WebApplicationBuilder.Build()
   at Program.<Main>$(String[] args) in /home/gustavo/Documentos/projeto_biblioteca/src/Program.cs:line 40
 ---> (Inner Exception #1) System.InvalidOperationException: Error while validating the service descriptor 'ServiceType: src.Nucleo.Controllers.LivroController Lifetime: Scoped ImplementationType: src.Nucleo.Controllers.LivroController': Unable to resolve service for type 'src.Portas.BDPort' while attempting to activate 'src.Nucleo.Repositorios.LivroRepository'.
 ---> System.InvalidOperationException: Unable to resolve service for type 'src.Portas.BDPort' while attempting to activate 'src.Nucleo.Repositorios.LivroRepository'.
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateArgumentCallSites(ServiceIdentifier serviceIdentifier, Type implementationType, CallSiteChain callSiteChain, ParameterInfo[] parameters, Boolean throwIfCallSiteNotFound)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateConstructorCallSite(ResultCache lifetime, ServiceIdentifier serviceIdentifier, Type implementationType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateExact(ServiceDescriptor descriptor, ServiceIdentifier serviceIdentifier, CallSiteChain callSiteChain, Int32 slot)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.TryCreateExact(ServiceIdentifier serviceIdentifier, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateCallSite(ServiceIdentifier serviceIdentifier, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateArgumentCallSites(ServiceIdentifier serviceIdentifier, Type implementationType, CallSiteChain callSiteChain, ParameterInfo[] parameters, Boolean throwIfCallSiteNotFound)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateConstructorCallSite(ResultCache lifetime, ServiceIdentifier serviceIdentifier, Type implementationType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateExact(ServiceDescriptor descriptor, ServiceIdentifier serviceIdentifier, CallSiteChain callSiteChain, Int32 slot)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.GetCallSite(ServiceDescriptor serviceDescriptor, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceProvider.ValidateService(ServiceDescriptor descriptor)
   --- End of inner exception stack trace ---
   at Microsoft.Extensions.DependencyInjection.ServiceProvider.ValidateService(ServiceDescriptor descriptor)
   at Microsoft.Extensions.DependencyInjection.ServiceProvider..ctor(ICollection`1 serviceDescriptors, ServiceProviderOptions options)<---

 ---> (Inner Exception #2) System.InvalidOperationException: Error while validating the service descriptor 'ServiceType: src.Nucleo.Repositorios.LivroRepository Lifetime: Scoped ImplementationType: src.Nucleo.Repositorios.LivroRepository': Unable to resolve service for type 'src.Portas.BDPort' while attempting to activate 'src.Nucleo.Repositorios.LivroRepository'.
 ---> System.InvalidOperationException: Unable to resolve service for type 'src.Portas.BDPort' while attempting to activate 'src.Nucleo.Repositorios.LivroRepository'.
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateArgumentCallSites(ServiceIdentifier serviceIdentifier, Type implementationType, CallSiteChain callSiteChain, ParameterInfo[] parameters, Boolean throwIfCallSiteNotFound)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateConstructorCallSite(ResultCache lifetime, ServiceIdentifier serviceIdentifier, Type implementationType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateExact(ServiceDescriptor descriptor, ServiceIdentifier serviceIdentifier, CallSiteChain callSiteChain, Int32 slot)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.GetCallSite(ServiceDescriptor serviceDescriptor, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceProvider.ValidateService(ServiceDescriptor descriptor)
   --- End of inner exception stack trace ---
   at Microsoft.Extensions.DependencyInjection.ServiceProvider.ValidateService(ServiceDescriptor descriptor)
   at Microsoft.Extensions.DependencyInjection.ServiceProvider..ctor(ICollection`1 serviceDescriptors, ServiceProviderOptions options)<---

 ---> (Inner Exception #3) System.InvalidOperationException: Error while validating the service descriptor 'ServiceType: src.Nucleo.Repositorios.EstudanteRepository Lifetime: Scoped ImplementationType: src.Nucleo.Repositorios.EstudanteRepository': Unable to resolve service for type 'src.Portas.BDPort' while attempting to activate 'src.Nucleo.Repositorios.EstudanteRepository'.
 ---> System.InvalidOperationException: Unable to resolve service for type 'src.Portas.BDPort' while attempting to activate 'src.Nucleo.Repositorios.EstudanteRepository'.
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateArgumentCallSites(ServiceIdentifier serviceIdentifier, Type implementationType, CallSiteChain callSiteChain, ParameterInfo[] parameters, Boolean throwIfCallSiteNotFound)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateConstructorCallSite(ResultCache lifetime, ServiceIdentifier serviceIdentifier, Type implementationType, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.CreateExact(ServiceDescriptor descriptor, ServiceIdentifier serviceIdentifier, CallSiteChain callSiteChain, Int32 slot)
   at Microsoft.Extensions.DependencyInjection.ServiceLookup.CallSiteFactory.GetCallSite(ServiceDescriptor serviceDescriptor, CallSiteChain callSiteChain)
   at Microsoft.Extensions.DependencyInjection.ServiceProvider.ValidateService(ServiceDescriptor descriptor)
   --- End of inner exception stack trace ---
   at Microsoft.Extensions.DependencyInjection.ServiceProvider.ValidateService(ServiceDescriptor descriptor)
   at Microsoft.Extensions.DependencyInjection.ServiceProvider..ctor(ICollection`1 serviceDescriptors, ServiceProviderOptions options)<---