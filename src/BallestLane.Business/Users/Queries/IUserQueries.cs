using Application.Abstractions.Messaging;
using BallestLane.Business.Users.Queries.GetById;

namespace BallestLane.Business;

public interface IUserQueries
{
    ValueTask<IResponse> Query<TQuery>(TQuery query, CancellationToken cancellationToken);
}


public class UserQueries(GetUserQueryHandler getUserQueryHandler) : IUserQueries
{
    public async ValueTask<IResponse> Query<TQuery>(TQuery query, CancellationToken cancellationToken) => query switch
    {
        GetUserByIdQuery _query => (IResponse) await getUserQueryHandler.Handle(_query, cancellationToken),
        _ => throw new NotImplementedException(),
    };
}