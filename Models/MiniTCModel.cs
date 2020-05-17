using System.IO;

namespace MiniTC.Models
{
    class MiniTCModel
    {
        public string[] LogicalDrivers
        {
            get { return Directory.GetLogicalDrives(); }
        }
    }
}
