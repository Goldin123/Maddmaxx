using Maddmaxx.Service.Services;
using Maddmaxx.Infrastructure.Factory;
using Maddmaxx.Infrastructure.Repository;
using Maddmaxx.Domain.Interfaces;
using MediatR;
using System.Reflection;

namespace Maddmaxx.Service;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddGrpc();

        // Register ISqlConnectionFactory with DI and pass IConfiguration
        builder.Services.AddSingleton<ISqlConnectionFactory>(sp =>
            new SqlConnectionFactory(builder.Configuration, "DefaultConnection")
        );
        builder.Services.AddScoped<IDocRepository, DocRepository>();

        // Register MediatR (scan the Application layer for command handlers)
        builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssemblies(
                // Replace with the actual assembly where your handlers live
                Assembly.Load("Maddmaxx.Application")
            )
        );

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        app.MapGrpcService<CaptureBusinessInformationService>();

        app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

        app.Run();
    }
}
