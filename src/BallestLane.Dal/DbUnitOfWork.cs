using Ballastlane.Domain.Abstractions;

namespace BallestLane.Dal;

public class DbUnitOfWork(AppDbContext db) : IDbUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) => db.SaveChangesAsync(cancellationToken);
}
