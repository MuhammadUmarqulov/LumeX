using Lumex.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lumex.Domain.Entities
{
    public class Input : Auditable
    {
        public string Text { get; set; }
    }
}
