using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.LSP.EX2.After
{
    internal class Square : IShape
    {
        public decimal Side { get; set; }
        public decimal Area()
        {
            return Side * Side;
        }
    }
}
