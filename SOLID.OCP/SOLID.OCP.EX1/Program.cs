using SOLID.OCP.EX1.After;

namespace SOLID.OCP.EX1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var quiz = new Quiz(QuestionBank.Generate());
            quiz.Print();
        }
    }
}
