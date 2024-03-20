using Application.Abstractions.Messaging;

namespace BallestLane.Business;

public interface IUserCommands
{
    ValueTask<string> Add(CreateUserCommand createUser);
    // ValueTask Update(UpdateUserCommand updateUser);
    // ValueTask Delete(DeleteUserCommand deleteUser);

    ValueTask<string> Send(ICommand command, CancellationToken cancellationToken);
    //T Send<T>(ICommand<string> command, CancellationToken cancellationToken);
}

public class UserCommands(CreateUserHandler createUserHandler) : IUserCommands
{
    public ValueTask<string> Add(CreateUserCommand createUser)
    {
        throw new NotImplementedException();
    }

    public async ValueTask<string> Send(ICommand command, CancellationToken cancellationToken)
    {
        string res = command switch 
        {
            CreateUserCommand userCommand =>  await createUserHandler.Handle(userCommand, cancellationToken),
            _ => "",
        };

        return res;
    }
}