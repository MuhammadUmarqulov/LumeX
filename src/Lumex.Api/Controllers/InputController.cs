using Lumex.Service.IServices;
using Lumex.Services.DTOs.Inputs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.OpenApi.Writers;

namespace Lumex.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputController : ControllerBase
    {
        private readonly IInputService inputService;

        public InputController(IInputService inputService)
        {
            this.inputService = inputService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(InputForCreationDTO inputForCreationDTO)
            => Ok(await inputService.CreateAsync(inputForCreationDTO));

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(long id)
            => Ok(await inputService.DeleteAsync(id));
    }
}
