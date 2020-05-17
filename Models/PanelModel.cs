using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MiniTC.Models
{
    class PanelModel
    {
        public List<string> insideFolder { get; private set; }

        public void SetFolderFiles(string path)
        {
            insideFolder = new List<string>();

            var folders = Directory.GetDirectories(path);
            var files = Directory.GetFiles(path);

            insideFolder.AddRange(folders.Select(x => "<D>" + Path.GetFileName(x)));
            insideFolder.AddRange(files.Select(x => Path.GetFileName(x)));
        }

        public string[] GetLogicalDrivers()
        => Directory.GetLogicalDrives();
    }
}
