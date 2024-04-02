using Application.Abstractions.Messaging;

namespace BallestLane.Business.Users.Queries.GetById;

public sealed record NftResponse(long Id, string UserId, string Name, string IpfsImage) : IResponse;