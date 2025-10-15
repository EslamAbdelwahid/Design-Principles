using SOLID.LSP.EX2.Before;

namespace SOLID.LSP.EX2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Square();
            rect.Width = 4;
            rect.Height = 5;
            Console.WriteLine(rect.GetArea()); // 25 ( this is wrong) the answer must be 20

        }
    }
}
