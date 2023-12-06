using Microsoft.EntityFrameworkCore;

namespace BallestLane.Dal;

public class AppDbContext(IConfiguration configuration) : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Nft> Nfts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(configuration["Database:ConnectionString"]);
    }

    public void SeedData()
    {
        this.Users.AddRange(
        new User { Id = "1", NickName = "User1", ProfilePicture = "path/to/picture1.jpg" },
            new User { Id = "2", NickName = "User2", ProfilePicture = "path/to/picture2.jpg" }
        );

        this.Nfts.AddRange(
            new Nft { Id = 1, Name = "Nft1", IpfsImage = "ipfs://image1" },
            new Nft { Id = 2, Name = "Nft2", IpfsImage = "ipfs://image2" }
        );
    }
}