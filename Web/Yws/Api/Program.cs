using Api;
using Microsoft.EntityFrameworkCore;
using Persistence.Database;

public class Program
{
    public static async Task Main(string[] args)
    {
        var webHost = CreateHostBuilder(args).Build();

        await ApplyMigrations(webHost.Services, webHost.Services.GetRequiredService<IConfiguration>());

        await webHost.RunAsync();
    }

    private static async Task ApplyMigrations(IServiceProvider serviceProvider, IConfiguration configuration)
    {
        using var scope = serviceProvider.CreateScope();

        await using RepositoryDbContext dbContext = scope.ServiceProvider.GetRequiredService<RepositoryDbContext>();

        await dbContext.Database.MigrateAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>())
            .ConfigureServices(services =>
                services.AddSingleton<IConfiguration>(WebApplication.CreateBuilder(args).Configuration));
}