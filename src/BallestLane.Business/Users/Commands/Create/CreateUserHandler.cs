using Application.Abstractions.Messaging;
using Ballastlane.Domain.Abstractions;
using Ballastlane.Domain.Repositories;
using BallestLane.Entities;

namespace BallestLane.Business;

public class CreateUserHandler(IUserRepository usersRepo, IDbUnitOfWork dbUnitOfWork) : ICommandHandler<CreateUserCommand, string>
{
    public async ValueTask<string> Handle(CreateUserCommand command, CancellationToken cancellationToken)
    {
        User user = new() { Id = command.Id, Nickname = command.Nickname, ProfilePicture = command.ProfilePicture };

        await usersRepo.Add(user);
        await dbUnitOfWork.SaveChangesAsync(cancellationToken);

        return user.Id;
    }
}
