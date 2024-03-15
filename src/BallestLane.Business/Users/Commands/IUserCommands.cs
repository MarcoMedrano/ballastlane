namespace BallestLane.Business;

public interface IUserCommands
{
    ValueTask<string> Add(CreateUserCommand createUser);
    ValueTask Update(UpdateUserCommand updateUser);
    ValueTask Delete(DeleteUserCommand deleteUser);
}