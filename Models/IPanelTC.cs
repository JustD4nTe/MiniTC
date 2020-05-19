using System.Collections.Generic;

namespace MiniTC.Models
{
    public interface IPanelTC
    {
        string CurrentPath { get; }
        string[] ListOfDrives { get; }
        List<string> FolderInside { get; }

        bool SetFoldersAndFilesOfCurrentFolder(string path);
        bool EnterFile(string fileName);
        void UpdateLogicalDrives();
    }
}
