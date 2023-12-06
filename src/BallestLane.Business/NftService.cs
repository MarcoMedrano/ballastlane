using BallestLane.Dal;
using BallestLane.Entities;

namespace BallestLane.Business;

public class NftService(INftRepository repo) : IService<Nft, long>
{
    public Task<Nft> GetById(long id) => repo.GetById(id);

    public Task<IEnumerable<Nft>> GetAll() => repo.GetAll();

    public Task Add(Nft nft) => repo.Add(nft);

    public Task Update(Nft nft) => repo.Update(nft);

    public Task Delete(long id) => repo.Delete(id);
}
