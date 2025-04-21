using GymGestor.Application.Models.InputModels.Member;
using GymGestor.Application.Services.Member.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GymGestor.API.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize]
public class MembersController : ControllerBase
{
    [HttpPost]
    [Authorize(Roles = "Admin, User")]
    public async Task<IActionResult> Create([FromServices] ICreateMemberService createMemberService, [FromBody] CreateMemberInputModel model)
    {
        await createMemberService.Create(model);

        return StatusCode(201);
    }
}
