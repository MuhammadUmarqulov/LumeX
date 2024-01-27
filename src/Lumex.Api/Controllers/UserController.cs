using Lumex.Service.Interfaces;
using Lumex.Services.DTOs.Users;
using Microsoft.AspNetCore.Mvc;

namespace Lumex.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    /// <summary>
    /// Delete by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async ValueTask<ActionResult<bool>> DeleteAsync([FromRoute] long id) =>
        Ok(await userService.DeleteAsync(id));
}
