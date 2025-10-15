using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.EX3.After
{
    public class FileReaderWriter : IReader, IWriter
    {
        public virtual string ReadFile(string path)
        {
            return File.ReadAllText(path);
        }

        public virtual void WriteFile(string path, string content)
        {
            File.WriteAllText(path, content);
        }
    }

}
