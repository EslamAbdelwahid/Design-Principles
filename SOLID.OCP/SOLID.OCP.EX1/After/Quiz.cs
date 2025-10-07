using SOLID.OCP.EX1.After;
using System;
using System.Collections.Generic;

namespace SOLID.OCP.EX1.After
{
    public class Quiz
    {
        public List<Question> Questions { get; }

        public Quiz(List<Question> questions)
        {
            this.Questions = questions;
        }
        public void Print()
        {
            foreach (var q in Questions)
            {
                q.Print();
                Console.WriteLine("\n\n");
            }

        }
    }
}