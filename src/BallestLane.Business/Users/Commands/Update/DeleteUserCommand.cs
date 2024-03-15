using Application.Abstractions.Messaging;

namespace BallestLane.Business;

public sealed record DeleteUserCommand(string Id) : ICommand;