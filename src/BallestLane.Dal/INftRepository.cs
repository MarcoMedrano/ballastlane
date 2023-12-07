namespace BallestLane.Dal;

public interface INftRepository : IRepository<Nft, long>
{
    Task<IEnumerable<Nft>?> GetByUserId(string userId);
}