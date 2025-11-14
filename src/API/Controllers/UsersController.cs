using Application.Users.Contracts;
using Application.Users.Services;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController(IUserService userService, IUserRepository userRepository) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpPost("Register")]
    public async Task<IActionResult> Register([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        int userId = await _userService.CreateUserAsync(request, cancellationToken);

        //TODO: load with new user GetByUserId
        return Ok(userId);
    }
}