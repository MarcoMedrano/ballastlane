using BallestLane.Dal;


namespace BallestLane.IntegrationTests;

public class DeleteUserTests(TestContainerFixture fixture) :
    IClassFixture<TestContainerFixture>
{

    [Fact]
    public async Task Delete_RemovesUserFromDatabase()
    {
        var userRepository = new UserRepository(fixture.Config);

        // Insert test data into the database
        await InsertTestData();

        // Act
        await userRepository.Delete("testUserId");

        // Assert
        var result = await userRepository.GetById("testUserId");
        Assert.Null(result);
    }


    private async Task InsertTestData()
    {
        fixture.Db.Users.Add(new() { Id = "testUserId", NickName = "TestUser", ProfilePicture = "ipfs://asdfas" });
        await fixture.Db.SaveChangesAsync();
    }
}