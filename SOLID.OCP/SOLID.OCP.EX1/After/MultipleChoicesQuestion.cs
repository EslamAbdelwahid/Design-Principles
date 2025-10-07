using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.OCP.EX1.After
{
    public class MultipleChoicesQuestion : Question
    {
        public List<string> Choices { get; set; } = new List<string>();

        public override void Print()
        {
            Console.WriteLine($"{Title} [{Mark}],         [{QuestionType.MULTIPLECHOICE}]");

            foreach (var choice in Choices)
            {
                Console.WriteLine($"  {choice}");
            }
        }
    }
}
