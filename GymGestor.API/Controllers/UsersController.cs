using GymGestor.Application.Models.InputModels.User;
using GymGestor.Application.Services.User.ReadOnly;
using GymGestor.Application.Services.User.WriteOnly.Create;
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
    public async Task<IActionResult> Update([FromServices] IUpdateUserService service, [FromBody] UpdateUserInputModel model, Guid id)
    {
        await service.Update(model, id);

        return NoContent();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromServices] IUserReadOnlyService service)
    {
        var users = await service.GetAll();

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromServices] IUserReadOnlyService service, Guid id)
    {
        var user = await service.GetById(id);

        return Ok(user);
    }
}
