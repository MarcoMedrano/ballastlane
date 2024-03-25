using BallestLane.Dtos.Nft;
using BallestLane.Dtos.User;
using Refit;

namespace BallastLane.Infraestructure.Api;

public interface IUsersController
{
    [Get("/api/users/{id}")]
    Task<UserDto?> GetById(string id, CancellationToken cancellationToken);

    [Get("/api/users")]
    Task<IEnumerable<UserDto>> Get(CancellationToken cancellationToken);

    [Post("/api/users")]
    Task<string> Add(UserDto dto, CancellationToken cancellationToken);

    [Patch("/api/users")]
    Task Update(UserDto dto, CancellationToken cancellationToken);

    [Delete("/api/users/{id}")]
    Task Delete(string id, CancellationToken cancellationToken);

    [Get("/api/users/{id}/nfts")]
    Task<IEnumerable<NftDto>?> GetNfts(string id, CancellationToken cancellationToken);
}