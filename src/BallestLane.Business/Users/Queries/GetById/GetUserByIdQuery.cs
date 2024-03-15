using Application.Abstractions.Messaging;

namespace BallestLane.Business.Users.Queries.GetById;

public sealed record GetUserByIdQuery(string Id) : IQuery<UserResponse>;
