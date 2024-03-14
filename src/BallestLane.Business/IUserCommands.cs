namespace BallestLane.Business;

public interface IUserCommands
{
    ValueTask<string> Add(CreateUserCommand createUser);

    // Task Update(T nft);

    // Task Delete(K id);
}