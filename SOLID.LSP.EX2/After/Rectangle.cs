using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.LSP.EX2.After
{
    internal class Rectangle : IShape
    {
        public decimal Width { get; set; }
        public decimal Height { get; set; }

        public decimal Area()
        {
            return Width * Height;
        }
    }
}
