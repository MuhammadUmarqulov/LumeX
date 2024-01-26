
using Lumex.Domain.Commons;

namespace Lumex.Domain.Entities
{
    public class Product : Auditable
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsNew { get; set; }
    }
}
