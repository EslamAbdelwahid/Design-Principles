using SOLID.EX3.After;


namespace SOLID.EX3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "E:\\visual staudio\\vs projects\\My .Net Learning\\Design Principles\\test.txt";
            var reader = new ReadOnlyFileReader();
            Console.WriteLine(reader.ReadFile(path));

            var writer = new FileReaderWriter();
            writer.WriteFile(path, "LSP fixed!");

        }
    }
}
