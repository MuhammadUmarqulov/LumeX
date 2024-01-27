using Lumex.Domain.Entities;
using Lumex.Service.DTOs.Users;
using Lumex.Service.Interfaces;
using Lumex.Services.DTOs.Users;
using Lumex.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Lumex.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService authService;
    private readonly IUserService userService;
    public AuthController(IAuthService authService, IUserService userService)
    {
        this.authService = authService;
        this.userService = userService;
    }

    /// <summary>
    /// Authentification
    /// </summary>
    [HttpPost("login")]
    public async ValueTask<IActionResult> Login(UserForLoginDTO dto)
    {
        var token = await authService.GenerateToken(dto.Email, dto.Password);
        return Ok(new
        {
            token
        });
    }

    /// <summary>
    /// Register
    /// </summary>
    /// <param name="dto"></param>
    /// <returns></returns>
    [HttpPost("register")]
    public async ValueTask<ActionResult<User>> CreateAsync(UserForCreationDTO dto) =>
       Ok(await userService.CreateAsync(dto));
}
