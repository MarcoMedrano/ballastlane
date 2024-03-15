using BallastLane.Api.Authorization;
using BallastLane.Infraestructure.Api;
using BallestLane.Dtos.Nft;
using BallestLane.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace BallastLane.Api;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserCommands userCommands, IUserService service, ILogger<UsersController> logger) : ControllerBase, IUsersController
{
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<UserDto?> GetById(string id) => (await service.GetById(id)).Adapt<UserDto>();

    [AllowAnonymous]
    [HttpGet]
    public async Task<IEnumerable<UserDto>> Get() => (await service.GetAll()).Adapt<IEnumerable<UserDto>>();

    [HttpPost]
    public async Task<string> Add(UserDto dto)
    {
        logger.LogDebug("Trying to add user {0}", dto.Id);
        this.ThrowIfNotAuthorized(dto.Id);
        return await userCommands.Add(dto.Adapt<CreateUserCommand>());
    }

    [HttpPatch]
    public Task Update(UserDto dto)
    {
        logger.LogDebug("Trying to modify user {0}" , dto.Id);
        this.ThrowIfNotAuthorized(dto.Id);
        return service.Update(dto.Adapt<User>());
    }

    [HttpDelete("{id}")]
    public Task Delete(string id)
    {
        logger.LogDebug("Trying to delete user {0}", id);
        this.ThrowIfNotAuthorized(id);
        return service.Delete(id);
    }

    [HttpGet("{id}/nfts")]
    public async Task<IEnumerable<NftDto>?> GetNfts(string id) => (await service.GetNfts(id)).Adapt<IEnumerable<NftDto>>();
}
