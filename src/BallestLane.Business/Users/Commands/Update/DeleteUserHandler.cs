using Application.Abstractions.Messaging;
using Ballastlane.Domain.Abstractions;
using Ballastlane.Domain.Repositories;

namespace BallestLane.Business;

public class DeleteUserHandler(IUserRepository usersRepo, IDbUnitOfWork dbUnitOfWork) : ICommandHandler<DeleteUserCommand>
{
    public async ValueTask Handle(DeleteUserCommand command, CancellationToken cancellationToken)
    {
        await usersRepo.Delete(command.Id);
        await dbUnitOfWork.SaveChangesAsync(cancellationToken);
    }
}
