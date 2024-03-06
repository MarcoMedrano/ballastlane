using Ballastlane.Domain.Repositories.Base;
using BallestLane.Entities;

namespace Ballastlane.Domain.Repositories;

public interface IUserRepository : IRepository<User, string>
{
}