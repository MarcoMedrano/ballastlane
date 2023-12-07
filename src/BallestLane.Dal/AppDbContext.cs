using Microsoft.EntityFrameworkCore;

namespace BallestLane.Dal;

public class AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration config) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Nft> Nfts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(config["Database:ConnectionString"]);
    }

    public void SeedData()
    {
        this.Users.AddRange(
        new User { Id = "1", NickName = "User1", ProfilePicture = "https://cloudflare-ipfs.com/ipfs/bafkreidcclwqy3i3bzihltneylgpwcrg5bsk5whkpe54jcw5tsphzflbze" }
        );

        this.Nfts.AddRange(
            new Nft { Name = "Nik", IpfsImage = "https://cloudflare-ipfs.com/ipfs/bafybeic5cxu67vlwcq4nepcreim2rnnuo7qeq5bzjnhjgyd7nvzxyae64m" },
            new Nft { Name = "Guns N'cats", IpfsImage = "https://cloudflare-ipfs.com/ipfs/bafybeihdy6e7ah357phyoqrvsdw4mqrkbshvfwfjocv7ubivuwb7mctor4" }
        );

        this.SaveChanges();
    }
}