using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MiniTC.Models
{
    class PanelModel : IPanelTC
    {
        public string[] ListOfDrives => Directory.GetLogicalDrives();

        public string CurrentPath { get; private set; }
        public List<string> FolderInside { get; private set; }

        public PanelModel() {}

        public bool SetFoldersAndFilesOfCurrentFolder(string path)
        {
            string[] folders, files;

            try
            {
                folders = Directory.GetDirectories(path);
                files = Directory.GetFiles(path);
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }

            FolderInside = new List<string>();

            // when we are on logical drive, we can't go up in the folder tree
            if (!ListOfDrives.Contains(Path.GetFullPath(path)))
            {
                FolderInside.Add("..");
            }

            FolderInside.AddRange(folders.Select(x => "<D>" + Path.GetFileName(x)));
            FolderInside.AddRange(files.Select(x => Path.GetFileName(x)));

            CurrentPath = Path.GetFullPath(path);

            return true;
        }

        public bool EnterFile(string fileName)
        {
            if (fileName.Contains("<D>"))
            {
                var filePath = Path.Combine(CurrentPath, fileName.Substring(3));
                return SetFoldersAndFilesOfCurrentFolder(filePath);
            }

            // move up
            if (fileName == "..")
            {
                var filePath = Path.Combine(CurrentPath, fileName);
                return SetFoldersAndFilesOfCurrentFolder(filePath);
            }

            return true;
        }
    }
}
