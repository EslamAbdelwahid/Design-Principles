namespace SOLID.EX3.After
{
    public class ReadOnlyFileReader : IReader
    {
        public string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }
    }

}
