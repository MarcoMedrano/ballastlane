using BallestLane.Dtos.Nft;
using Microsoft.AspNetCore.Mvc;

namespace BallastLane.Api;

[ApiController]
[Route("api/[controller]")]
public class NftsController(INftService service, ILogger<NftsController> logger) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<NftDto> GetById(long id) => (await service.GetById(id)).Adapt<NftDto>();

    [HttpGet]
    public async Task<IEnumerable<NftDto>> Get() => (await service.GetAll()).Adapt<IEnumerable<NftDto>>();

    [HttpPost]
    public Task<long> Add(NftCreateDto dto) => service.Add(dto.Adapt<Nft>());

    [HttpPatch]
    public Task Update(NftDto dto) => service.Update(dto.Adapt<Nft>());

    [HttpDelete("{id}")]
    public Task Delete(long id) => service.Delete(id);
}