using BallestLane.Dal;
using BallestLane.Entities;

namespace BallestLane.IntegrationTests;

public class AddUserTests(TestContainerFixture fixture) :
    IClassFixture<TestContainerFixture>
{
    [Fact]
    public async Task Add_AddsUserToDatabase()
    {
        var userRepository = new UserRepository(fixture.Config);

        // Arrange
        var userToAdd = new User { Id = "newUserId", NickName = "NewUser", ProfilePicture = "ipfs://newUserPicture" };

        // Act
        await userRepository.Add(userToAdd);

        // Assert
        var result = await userRepository.GetById("newUserId");
        Assert.NotNull(result);
        Assert.Equal("newUserId", result.Id);
        Assert.Equal("NewUser", result.NickName);
        Assert.Equal("ipfs://newUserPicture", result.ProfilePicture);
    }
}