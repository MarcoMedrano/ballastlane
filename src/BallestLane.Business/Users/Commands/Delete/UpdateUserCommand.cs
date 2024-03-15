using Application.Abstractions.Messaging;

namespace BallestLane.Business;

public sealed record UpdateUserCommand(string Id, string Nickname, string? ProfilePicture) : ICommand;