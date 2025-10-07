using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.OCP.EX1.After
{
    public class TrueFalseQuestion : Question
    {
        public override void Print()
        {
            Console.WriteLine($"{Title} [{Mark}],      [{QuestionType.TRUEFALSE}]");
            Console.WriteLine("  1. T");
            Console.WriteLine("  2. F");
        }
    }
}
