using BallestLane.Dal;

namespace BallestLane.IntegrationTests;


public class GetByIdTests : IAsyncLifetime
{
    private TestContainerFixture fixture = new();

    public async Task InitializeAsync()
    {
        await fixture.InitializeAsync();
    }

    public async Task DisposeAsync() => await fixture.DisposeAsync();

    [Fact]
    public async Task GetById_ValidId_ReturnsUserFromDatabase()
    {
        var userRepository = new UserRepository(fixture.Config);

        // Insert test data into the database
        await InsertTestData();

        // Act
        var result = await userRepository.GetById("testUserId");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("testUserId", result.Id);
        Assert.Equal("TestUser", result.NickName);
        Assert.Equal("ipfs://asdfas", result.ProfilePicture);
    }

    private async Task InsertTestData()
    {
        fixture.Db.Users.Add(new() { Id = "testUserId", NickName = "TestUser", ProfilePicture = "ipfs://asdfas" });
        await fixture.Db.SaveChangesAsync();
    }
}