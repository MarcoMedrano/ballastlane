using BallestLane.Dtos.User;

namespace BallastLane.Client;

public class UserState
{
    public UserDto User { get; set; } = new();
    public ulong ChainId { get; set; }
}