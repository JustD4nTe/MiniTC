using MiniTC.Models;
using MiniTC.ViewModel.BaseClass;
using System.Collections.Generic;

namespace MiniTC.ViewModel
{
    class MiniTCViewModel : ViewModelBase
    {
        #region prop
        private PanelModel left;
        private PanelModel right;

        public string[] LogicalDrivers
        {
            get { return left.GetLogicalDrivers(); }
        }

        public List<string> LeftInsideOfFolder
        {
            get { return left.insideFolder; }
        }
        
        public List<string> RightInsideOfFolder
        {
            get { return right.insideFolder; }
        }

        public string LeftSelectedDrive
        {
            set
            {
                if (value != null)
                {
                    left.SetFolderFiles(value);
                    onPropertyChanged(nameof(LeftSelectedDrive), nameof(LeftInsideOfFolder));
                }
            }
        }

        public string RightSelectedDrive
        {
            set
            {
                if (value != null)
                {
                    right.SetFolderFiles(value);
                    onPropertyChanged(nameof(RightSelectedDrive), nameof(RightInsideOfFolder));
                }
            }
        }
        #endregion

        public MiniTCViewModel()
        {
            left = new PanelModel();
            right = new PanelModel();
        }
    }
}
