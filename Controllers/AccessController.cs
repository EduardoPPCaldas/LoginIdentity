using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginSimulator.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AccessController : ControllerBase
{
    [HttpGet]
    [Authorize(Policy = "MinimalAge")]
    public IActionResult Get()
    {
        return Ok("Access allowed");
    }
}
