using System.Runtime.CompilerServices;
using System.Windows.Input;
using BallastLane.Api.Authorization;
using BallastLane.Infraestructure.Api;
using BallestLane.Business.Users.Queries.GetById;
using BallestLane.Dtos.Nft;
using BallestLane.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace BallastLane.Api;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserCommands userCommands, IUserQueries queries, IUserService service, ILogger<UsersController> logger) : ControllerBase, IUsersController
{
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<UserDto?> GetById(string id, CancellationToken cancellationToken) => (await queries.Query(new GetUserByIdQuery(id), cancellationToken)).Adapt<UserDto>();

    [AllowAnonymous]
    [HttpGet]
    public async Task<IEnumerable<UserDto>> Get(CancellationToken cancellationToken) => (await service.GetAll()).Adapt<IEnumerable<UserDto>>();

    [HttpGet("{id}/nfts")]
    public async Task<IEnumerable<NftDto>?> GetNfts(string id, CancellationToken cancellationToken) => (await service.GetNfts(id)).Adapt<IEnumerable<NftDto>>();

    [HttpPost]
    public async Task<string> Add(UserDto dto, CancellationToken cancellationToken)
    {
        logger.LogDebug("Trying to add user {0}", dto.Id);
        this.ThrowIfNotAuthorized(dto.Id);
        return await userCommands.Send(dto.Adapt<CreateUserCommand>(), cancellationToken);
    }

    [HttpPatch]
    public async Task Update(UserDto dto, CancellationToken cancellationToken)
    {
        logger.LogDebug("Trying to modify user {0}" , dto.Id);
        this.ThrowIfNotAuthorized(dto.Id);
        await userCommands.Send(dto.Adapt<UpdateUserCommand>(), cancellationToken);
    }

    [HttpDelete("{id}")]
    public async Task Delete(string id, CancellationToken cancellationToken)
    {
        logger.LogDebug("Trying to delete user {0}", id);
        this.ThrowIfNotAuthorized(id);
        await userCommands.Send(new DeleteUserCommand(id), cancellationToken);
    }
}
