using BallestLane.Dal;
using BallestLane.Entities;

namespace BallestLane.IntegrationTests;

// [Collection(nameof(CustomerApiFactoryTestCollection))]
public class UpdateUserTests(TestContainerFixture fixture) :
    IClassFixture<TestContainerFixture>
{

    [Fact]
    public async Task Update_UpdatesUserInDatabase()
    {
        var userRepository = new UserRepository(fixture.Config);

        // Insert test data into the database
        await InsertTestData();

        // Arrange
        var userToUpdate = new User
            { Id = "testUserId", NickName = "UpdatedUser", ProfilePicture = "ipfs://updatedPicture" };

        // Act
        await userRepository.Update(userToUpdate);

        // Assert
        var result = await userRepository.GetById("testUserId");
        Assert.NotNull(result);
        Assert.Equal("testUserId", result.Id);
        Assert.Equal("UpdatedUser", result.NickName);
        Assert.Equal("ipfs://updatedPicture", result.ProfilePicture);
    }

    private async Task InsertTestData()
    {
        fixture.Db.Users.Add(new() { Id = "testUserId", NickName = "TestUser", ProfilePicture = "ipfs://asdfas" });
        await fixture.Db.SaveChangesAsync();
    }
}