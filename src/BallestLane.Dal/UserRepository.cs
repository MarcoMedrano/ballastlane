
namespace BallestLane.Dal;

public class UserRepository : IUserRepository
{
    public Task<User> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<User>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Add(User entity)
    {
        throw new NotImplementedException();
    }

    public Task Update(User entity)
    {
        throw new NotImplementedException();
    }

    public Task Delete(string id)
    {
        throw new NotImplementedException();
    }
}