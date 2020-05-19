using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniTC.Models
{
    public interface IPanelTC
    {
        string CurrentPath { get; }
        string[] ListOfDrives { get; }
        List<string> FolderInside { get; }

        bool SetFoldersAndFilesOfCurrentFolder(string path);
        bool EnterFile(string fileName);
    }
}
