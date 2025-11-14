using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;


[ApiController]
[Route("[controller]")]
public class UserController:ControllerBase
{
    [HttpPost("Register")]
    public async Task<IActionResult> Register()
    {
        return Ok();
    }
}