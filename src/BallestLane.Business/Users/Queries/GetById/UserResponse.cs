namespace BallestLane.Business.Users.Queries.GetById;

public sealed record UserResponse(string Id, string Nickname, string? ProfilePicture);