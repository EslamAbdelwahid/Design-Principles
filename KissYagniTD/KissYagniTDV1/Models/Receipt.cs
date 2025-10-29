using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KissYagniTDV1.Models
{
    public record Receipt
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Method { get; set; }

    }
}
