using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTC.Models
{
    class FileManager : IFileManager
    {
        public void Copy(string source, string fileName, string destination)
        {
            string sourceFile = Path.Combine(source, fileName);
            string destFile = Path.Combine(destination, fileName);

            File.Copy(sourceFile, destFile, true);
        }
    }
}
