using BallestLane.Dal;
using BallestLane.Entities;

namespace BallestLane.IntegrationTests;

// [Collection(nameof(CustomerApiFactoryTestCollection))]
public class GetAllTests(TestContainerFixture fixture) :
    IClassFixture<TestContainerFixture>
{

    [Fact]
    public async Task GetAll_ReturnsAllUsersFromDatabase()
    {
        var userRepository = new UserRepository(fixture.Config);

        // Insert test data into the database
        await InsertTestData();

        // Act
        var results = await userRepository.GetAll();

        // Assert
        Assert.NotNull(results);
        Assert.NotEmpty(results);
        Assert.Equal(1, results.Count());

        var result = results.First();
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