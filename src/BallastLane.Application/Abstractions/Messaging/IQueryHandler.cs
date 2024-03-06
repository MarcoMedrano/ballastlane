namespace Application.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    ValueTask<TResponse> Handle(TQuery QUERY, CancellationToken cancellationToken);
}