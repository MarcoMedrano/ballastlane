using Application.Abstractions.Messaging;

namespace BallestLane.Business.Users.Queries.GetNftsById;

public sealed record GetNftsByUserIdQuery(string Id) : IQuery<NftListsResponse>;
