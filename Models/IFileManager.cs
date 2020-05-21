using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTC.Models
{
    interface IFileManager
    {
        bool Copy(string source, string fileName, string destination);
    }
}
