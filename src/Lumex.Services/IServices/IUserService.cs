using Lumex.Services.DTOs.Users;

namespace Lumex.Service.Interfaces
{
    public interface IUserService
    {
        ValueTask<UserForViewModel> CreateAsync(UserForCreationDTO userForCreationDTO);

        ValueTask<bool> DeleteAsync(long id);
    }
}
