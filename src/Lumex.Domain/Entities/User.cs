using Lumex.Domain.Commons;

namespace Lumex.Domain.Entities
{
    public class User : Auditable
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
