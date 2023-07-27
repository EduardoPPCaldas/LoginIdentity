using LoginSimulator.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LoginSimulator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    public IActionResult CreateUser(
        [FromBody] CreateUserDTO dto)
    {
        throw new NotImplementedException();
    }
}
