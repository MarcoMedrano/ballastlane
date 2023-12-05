namespace BallestLane.Dal;

public class NftRepository : INftRepository
{
    public Task<Nft> GetById(ulong id) => throw new NotImplementedException();

    public Task<IEnumerable<Nft>> GetAll() => throw new NotImplementedException();

    public Task Add(Nft entity) => throw new NotImplementedException();

    public Task Update(Nft entity) => throw new NotImplementedException();

    public Task Delete(ulong id) => throw new NotImplementedException();
}
