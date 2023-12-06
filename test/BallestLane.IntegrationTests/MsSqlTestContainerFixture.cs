
using BallestLane.Dal;
using Microsoft.Extensions.Configuration;

namespace BallestLane.IntegrationTests;

public class MsSqlTestContainerFixture : IAsyncLifetime
{
    public MsSqlContainer Container { get; }
    public IConfiguration Config { get; }
    public AppDbContext Db { get; set; }

    public MsSqlTestContainerFixture()
    {
        Container = new MsSqlBuilder()
            .WithPassword(Guid.NewGuid().ToString("D"))
            .Build();
        Config = new ConfigurationManager();
        Db = new (Config);
    }

    public async Task InitializeAsync()
    {
        await Container.StartAsync();
        var conneciton = Container.GetConnectionString();

        Config["Database:ConnectionString"] = conneciton;
        await Db.Database.EnsureCreatedAsync();
    }

    public async Task DisposeAsync()
    {
        await Db.DisposeAsync();
        await Container.StopAsync();
    }

    // public MsSqlTestContainerFixture WithCompanies()
    // {
    //     return this;
    // }
}