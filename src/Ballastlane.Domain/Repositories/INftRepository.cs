using Ballastlane.Domain.Repositories.Base;
using BallestLane.Entities;

namespace Ballastlane.Domain.Repositories;

public interface INftRepository : IRepository<Nft, long>
{
    Task<IEnumerable<Nft>?> GetByUserId(string userId);
}