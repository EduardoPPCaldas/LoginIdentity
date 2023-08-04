using AutoMapper;
using LoginSimulator.DTOs;
using LoginSimulator.Models;
using LoginSimulator.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LoginSimulator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpPost("sign-up")]
    public async Task<IActionResult> CreateUser(
        [FromBody] CreateUserDTO dto,
        [FromServices] UserService userService)
    {
        var user = await userService.Create(dto);
        return Created("", user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(
        [FromServices] UserService userService,
        [FromBody] LoginUserDTO dto)
    {
        var token = await userService.Login(dto);
        return Ok(token);
    }
}
