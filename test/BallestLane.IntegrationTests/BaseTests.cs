namespace BallestLane.IntegrationTests;

public abstract class BaseTests(TestContainerFixture fixture) : IClassFixture<TestContainerFixture>
{
    protected async Task InsertUserData()
    {
        fixture.Db.Users.Add(new() { Id = "testUserId", NickName = "TestUser", ProfilePicture = "ipfs://asdfas" });
        await fixture.Db.SaveChangesAsync();
    }

    protected async Task InsertNftData()
    {
        // Insert sample Nft data
        fixture.Db.Nfts.Add(new ()
        {
            Name = "TestNft1",
            IpfsImage = "ipfs://testimage1"
        });

        fixture.Db.Nfts.Add(new ()
        {
            Name = "TestNft2",
            IpfsImage = "ipfs://testimage2"
        });

        fixture.Db.Nfts.Add(new ()
        {
            Name = "TestNft3",
            IpfsImage = "ipfs://testimage3"
        });

        await fixture.Db.SaveChangesAsync();
    }
}