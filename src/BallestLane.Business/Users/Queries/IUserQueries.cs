using BallestLane.Business.Users.Queries.GetById;

namespace BallestLane.Business;

public interface IUserQueries
{
    ValueTask<UserResponse> GetById(GetUserByIdQuery query, CancellationToken cancellationToken);
}


public class UserQueries(GetUserQueryHandler getUserQueryHandler) : IUserQueries
{
    public ValueTask<UserResponse> GetById(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        return getUserQueryHandler.Handle(query, cancellationToken);
    }
}