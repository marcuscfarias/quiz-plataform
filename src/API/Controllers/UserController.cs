using Application.Users.Contracts;
using Application.Users.Services;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(IUserService userService, IUserRepository userRepository) : ControllerBase
{
    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        int userId = await userService.CreateUserAsync(request, cancellationToken);

        //TODO: load with new user GetByUserId
        return Ok(userId);
    }
}