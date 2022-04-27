﻿// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Tarmac.Shared.DBO.DAL;
using Tarmac.Shared.Migrator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.EnvironmentVariables;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Tarmac.Shared.Models;

static void ConfigureServices(IServiceCollection services)
{
    services.AddLogging(builder =>
    {
        builder.AddConsole();
        builder.AddDebug();
    });
    var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false)
        .AddEnvironmentVariables()
        .Build();
    services.Configure<AppSettings>(configuration.GetSection("App"));
    services.AddDbContext<TarmacDBContext>(dbContextOptions =>
    {
        dbContextOptions
            .UseMySql(
                configuration.GetConnectionString("DefaultConnection"),
                new MariaDbServerVersion(new Version(configuration.GetConnectionString("MariaDBVersion"))),
                assembly => assembly.MigrationsAssembly(typeof(TarmacDBContext).Assembly.FullName))
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    });
    services.AddTransient<App>();
}
var services = new ServiceCollection();
ConfigureServices(services);
using var serviceProvider = services.BuildServiceProvider();
await serviceProvider.GetService<App>().Run(args);



public class AppSettings
{
    public string TempDirectory { get; set; }

}
public class App
{
    private readonly AppSettings _appSettings;
    private readonly ILogger<App> _logger;
    private readonly TarmacDBContext _context;
    public App(IOptions<AppSettings>appSettings, ILogger<App> logger, TarmacDBContext context)
    {
        _appSettings = appSettings?.Value ?? throw new ArgumentNullException(nameof(appSettings));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    public async Task Run(string[] args)
    {
        Console.WriteLine("Migrate Objects");
        _logger.LogInformation("Starting");
        //loadFile
#if DEBUG
        var json = File.ReadAllText("J:\\artists.json");
#else
var json = File.ReadAllText(args[0]);
#endif
        var oldArtists = JsonConvert.DeserializeObject<List<OldArtist>>(json);
        var newArtists = new List<Artist>();
        var stages = _context.Stages.ToList();
        foreach (var artist in oldArtists)
        {

        }

        Console.WriteLine(String.Join<OldArtist>(",", oldArtists.ToArray()));
        //migrate the stuff
        _logger.LogInformation("Finished");
        await Task.CompletedTask;
    }
}

