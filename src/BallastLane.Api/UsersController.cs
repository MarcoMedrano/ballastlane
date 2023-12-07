using BallastLane.Api.Authorization;
using BallastLane.Infraestructure.Api;
using BallestLane.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace BallastLane.Api;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService service, ILogger<UsersController> logger) : ControllerBase, IUsersController
{
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<UserDto?> GetById(string id) => (await service.GetById(id)).Adapt<UserDto>();

    [AllowAnonymous]
    [HttpGet]
    public async Task<IEnumerable<UserDto>> Get() => (await service.GetAll()).Adapt<IEnumerable<UserDto>>();

    [HttpPost]
    public Task<string> Add(UserDto dto)
    {
        this.ThrowIfNotAuthorized(dto.Id);
        return service.Add(dto.Adapt<User>());
    }

    [HttpPatch]
    public Task Update(UserDto dto)
    {
        this.ThrowIfNotAuthorized(dto.Id);
        return service.Update(dto.Adapt<User>());
    }

    [HttpDelete("{id}")]
    public Task Delete(string id)
    {
        this.ThrowIfNotAuthorized(id);
        return service.Delete(id);
    }
}
