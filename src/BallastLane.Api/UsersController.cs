using BallestLane.Dtos.User;
using Microsoft.AspNetCore.Mvc;

namespace BallastLane.Api;

[ApiController]
[Route("api/[controller]")]
public class UsersController(IUserService service, ILogger<UsersController> logger) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<UserDto> GetById(string id) => (await service.GetById(id)).Adapt<UserDto>();

    [HttpGet]
    public async Task<IEnumerable<UserDto>> Get() => (await service.GetAll()).Adapt<IEnumerable<UserDto>>();

    [HttpPost]
    public Task<string> Add(UserDto dto) => service.Add(dto.Adapt<User>());

    [HttpPatch]
    public Task Update(UserDto dto) => service.Update(dto.Adapt<User>());

    [HttpDelete("{id}")]
    public Task Delete(string id) => service.Delete(id);
}
