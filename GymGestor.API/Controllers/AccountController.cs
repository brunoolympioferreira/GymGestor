﻿using GymGestor.Application.Models.InputModels.Account;
using GymGestor.Application.Services.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymGestor.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromServices] ILoginService service, [FromBody] LoginInputModel model)
    {
        var result = await service.Login(model);

        return Ok(result);
    }
}
