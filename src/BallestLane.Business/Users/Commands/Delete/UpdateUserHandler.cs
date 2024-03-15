using Application.Abstractions.Messaging;
using Ballastlane.Domain.Abstractions;
using Ballastlane.Domain.Repositories;
using BallestLane.Entities;

namespace BallestLane.Business;

public class UpdateUserHandler(IUserRepository usersRepo, IDbUnitOfWork dbUnitOfWork) : ICommandHandler<UpdateUserCommand>
{
    public async ValueTask Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        User user = new() { Id = command.Id, Nickname = command.Nickname, ProfilePicture = command.ProfilePicture };

        await usersRepo.Update(user);
        await dbUnitOfWork.SaveChangesAsync(cancellationToken);
    }
}
