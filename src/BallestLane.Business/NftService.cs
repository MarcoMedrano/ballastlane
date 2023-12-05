using BallestLane.Entities;

namespace BallestLane.Business;

public class NftService : IService<Nft, ulong>
{
    public Task<Nft> GetById(ulong id) => throw new NotImplementedException();

    public Task<IEnumerable<Nft>> GetAll() => throw new NotImplementedException();

    public Task Add(Nft entity) => throw new NotImplementedException();

    public Task Update(Nft entity) => throw new NotImplementedException();

    public Task Delete(ulong id) => throw new NotImplementedException();
}
