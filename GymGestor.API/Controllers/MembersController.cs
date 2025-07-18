﻿using GymGestor.Application.Models.InputModels.Member;
using GymGestor.Application.Services.Member.Create;
using GymGestor.Application.Services.Member.ReadOnly;
using GymGestor.Application.Services.Member.Update;
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

    [HttpGet]
    [Authorize(Roles = "Admin, User")]
    public async Task<IActionResult> GetAll([FromServices] IMemberReadOnlyService memberReadOnlyService)
    {
        var members = await memberReadOnlyService.GetAll();

        return Ok(members);
    }

    [HttpGet("{id:guid}")]
    [Authorize(Roles = "Admin, User")]
    public async Task<IActionResult> GetById([FromServices] IMemberReadOnlyService memberReadOnlyService, Guid id)
    {
        var member = await memberReadOnlyService.GetById(id);
        return Ok(member);
    }

    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin, User")]
    public async Task<IActionResult> Update([FromServices] IUpdateMemberService updateMemberService, [FromBody] UpdateMemberInputModel model, Guid id)
    {
        await updateMemberService.Update(model, id);
        return NoContent();
    }
}
