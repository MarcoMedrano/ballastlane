using BallestLane.Dtos.Nft;
using Refit;

namespace BallastLane.Infraestructure.Api;

public interface INftsController
{
    [Get("/api/nfts/{id}")]
    Task<NftDto?> GetById(long id);

    [Get("/api/nfts")]
    Task<IEnumerable<NftDto>> Get();

    [Post("/api/nfts")]
    Task<long> Add(NftCreateDto dto);

    [Patch("/api/nfts")]
    Task Update(NftDto dto);

    [Delete("/api/nfts/{id}")]
    Task Delete(long id);
}