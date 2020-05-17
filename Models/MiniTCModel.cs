using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
