using BallestLane.Dtos.Nft;
using BallestLane.Entities;

namespace BallestLane.Business;

public interface IUserService : IService<User, string>
{
    Task<IEnumerable<Nft>?> GetNfts(string userId);
}