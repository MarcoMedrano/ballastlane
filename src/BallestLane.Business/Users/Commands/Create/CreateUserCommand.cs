using Application.Abstractions.Messaging;

namespace BallestLane.Business;

public sealed record CreateUserCommand(string Id, string Nickname, string? ProfilePicture) : ICommand<string>;
