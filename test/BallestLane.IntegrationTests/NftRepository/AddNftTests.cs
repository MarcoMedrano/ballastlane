using BallestLane.Entities;

namespace BallestLane.IntegrationTests.NftRepository;

public class AddNftTests(TestContainerFixture fixture) : BaseTests(fixture)
{
    [Fact]
    public async Task Add_AddsNftToDatabase()
    {
        // Arrange
        var repository = new Dal.NftRepository(fixture.Config);

        // Act
        await repository.Add(new Nft
        {
            Id = 1,
            Name = "Test Nft",
            IpfsImage = "ipfs://testimage"
        });

        // Assert
        var addedNft = await repository.GetById(1);
        Assert.NotNull(addedNft);
        Assert.Equal("Test Nft", addedNft.Name);
    }
}