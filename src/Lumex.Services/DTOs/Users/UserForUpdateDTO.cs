using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Lumex.Services.DTOs.Users
{
    public class UserForUpdateDTO
    {
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
