using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MiniTC.Models
{
    class PanelModel
    {
        public List<string> insideFolder { get; private set; }

        public string currentPath { get; private set; }

        public bool SetFoldersAndFilesOfCurrentFolder(string path)
        {
            string[] folders, files;           

            try
            {
                folders = Directory.GetDirectories(path);
                files = Directory.GetFiles(path);
            }
            catch (UnauthorizedAccessException e) 
            {
                return false;
            }

            insideFolder = new List<string>();
            insideFolder.AddRange(folders.Select(x => "<D>" + Path.GetFileName(x)));
            insideFolder.AddRange(files.Select(x => Path.GetFileName(x)));

            currentPath = path;

            return true;
        }

        public bool EnterFile(string fileName)
        {
            if(fileName.Contains("<D>"))
            {
                var filePath = currentPath + @"\" + fileName.Substring(3);
                return SetFoldersAndFilesOfCurrentFolder(filePath);
            }

            return true;
        }

        public string[] GetLogicalDrivers()
        => Directory.GetLogicalDrives();
    }
}
