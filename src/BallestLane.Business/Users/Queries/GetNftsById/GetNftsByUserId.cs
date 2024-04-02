using Application.Abstractions.Messaging;

namespace BallestLane.Business.Users.Queries.GetById;

public sealed record GetNftsByUserId(string Id) : IQuery<IEnumerable<NftResponse>>;
