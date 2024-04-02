using Application.Abstractions.Messaging;
using Ballastlane.Domain.Repositories;

namespace BallestLane.Business.Users.Queries.GetById;

public sealed class GetNftsByUserIdQueryHandler(INftRepository nftRepo) : IQueryHandler<GetNftsByUserId, IEnumerable<NftResponse>>
{
    public async ValueTask<IEnumerable<NftResponse>> Handle(
        GetNftsByUserId query,
        CancellationToken cancellationToken)
    {
        var nfts = await nftRepo.GetByUserId(query.Id);

        if(nfts == null) return Array.Empty<NftResponse>();
        return nfts.Select(n => new NftResponse(n.Id, n.UserId, n.Name, n.IpfsImage));
    }
}