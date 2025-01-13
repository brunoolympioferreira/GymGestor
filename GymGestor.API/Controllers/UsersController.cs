using GymGestor.Application.Models.InputModels.User;
using GymGestor.Application.Services.User.WriteOnly;
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
        [FromServices] IUserWriteOnlyService service,
        [FromBody] CreateUserInputModel model)
    {
        await service.Create(model);

        return Created();
    }
}
