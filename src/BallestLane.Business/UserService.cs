using BallestLane.Dal;
using BallestLane.Dtos.Nft;
using BallestLane.Entities;

namespace BallestLane.Business;

public class UserService(IUserRepository repo, INftRepository nftRepo) : IUserService
{
    public Task<User> GetById(string id) => repo.GetById(id);

    public Task<IEnumerable<User>> GetAll() => repo.GetAll();

    public Task<string> Add(User entity) => repo.Add(entity);

    public Task Update(User entity) => repo.Update(entity);

    public Task Delete(string id) => repo.Delete(id);
    public Task<IEnumerable<Nft>?> GetNfts(string userId)
    {
        return nftRepo.GetByUserId(userId);
    }
}
