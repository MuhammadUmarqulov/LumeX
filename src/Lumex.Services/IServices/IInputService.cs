using Lumex.Services.DTOs.Inputs;
using Lumex.Services.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumex.Service.IServices
{
    public interface IInputService
    {
        ValueTask<InputForCreationDTO> CreateAsync(InputForCreationDTO inputForCreationDTO);

        ValueTask<bool> DeleteAsync(long id);
    }
}
