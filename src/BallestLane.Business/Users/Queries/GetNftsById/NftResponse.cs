using Application.Abstractions.Messaging;

namespace BallestLane.Business.Users.Queries.GetNftsById;


public sealed record NftListsResponse(IEnumerable<NftResponse> Nfts) : IResponse;
public sealed record NftResponse(long Id, string UserId, string Name, string IpfsImage);