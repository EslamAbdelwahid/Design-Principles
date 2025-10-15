namespace SOLID.EX3.Before
{
    public class ReadOnlyFileReader : FileReader
    {
        public override void WriteFile(string path, string content)
        {
            throw new NotSupportedException("Cannot write in read-only mode!");
        }
    }

}
