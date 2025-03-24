using GymGestor.Application.Models.InputModels.User;
using GymGestor.Application.Services.User.ReadOnly;
using GymGestor.Application.Services.User.WriteOnly.Create;
using GymGestor.Application.Services.User.WriteOnly.Delete;
using GymGestor.Application.Services.User.WriteOnly.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymGestor.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    [AllowAnonymous]
    public async Task<IActionResult> Create(
        [FromServices] ICreateUserService service,
        [FromBody] CreateUserInputModel model)
    {
        await service.Create(model);

        return Created();
    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Admin, User")]
    public async Task<IActionResult> Update([FromServices] IUpdateUserService service, [FromBody] UpdateUserInputModel model, Guid id)
    {
        await service.Update(model, id);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete([FromServices] IRemoveUserService service, Guid id)
    {
        await service.Remove(id);

        return NoContent();
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAll([FromServices] IUserReadOnlyService service)
    {
        var users = await service.GetAll();

        return Ok(users);
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Admin, User")]
    public async Task<IActionResult> GetById([FromServices] IUserReadOnlyService service, Guid id)
    {
        var user = await service.GetById(id);

        return Ok(user);
    }
}
