namespace BallestLane.IntegrationTests;

public abstract class BaseTests(TestContainerFixture fixture) : IClassFixture<TestContainerFixture>
{
    protected async Task InsertUserData()
    {
        fixture.Db.Users.Add(new() { Id = "testUserId", NickName = "TestUser", ProfilePicture = "ipfs://asdfas" });
        await fixture.Db.SaveChangesAsync();
    }
}