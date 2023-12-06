using BallestLane.Dal;
using BallestLane.Entities;

namespace BallestLane.Business;

public class UserService(IUserRepository repo) : IUserService
{
    public Task<User> GetById(string id) => repo.GetById(id);

    public Task<IEnumerable<User>> GetAll() => repo.GetAll();

    public Task<string> Add(User entity) => repo.Add(entity);

    public Task Update(User entity) => repo.Update(entity);

    public Task Delete(string id) => repo.Delete(id);
}
