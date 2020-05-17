using MiniTC.Models;
using MiniTC.ViewModel.BaseClass;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

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
                    left.SetFoldersAndFilesOfCurrentFolder(value);
                    onPropertyChanged(nameof(LeftSelectedDrive), nameof(LeftInsideOfFolder), nameof(LeftPath));
                }
            }
        }

        public string RightSelectedDrive
        {
            set
            {
                if (value != null)
                {
                    right.SetFoldersAndFilesOfCurrentFolder(value);
                    onPropertyChanged(nameof(RightSelectedDrive), nameof(RightInsideOfFolder), nameof(RightPath));
                }
            }
        }

        public string LeftPath
        {
            get { return left.currentPath; }
        }

        public string RightPath
        {
            get { return right.currentPath; }
        }


        private string leftSelectedFile;
        public string LeftSelectedFile
        {
            set { leftSelectedFile = value; }
        }

        private string rightSelectedFile;
        public string RightSelectedFile
        {
            set { rightSelectedFile = value; }
        }

        #endregion

        #region Command
        private ICommand leftEnterTheSelectedFolder = null;
        public ICommand LeftEnterTheSelectedFolder
        {
            get
            {
                if (leftEnterTheSelectedFolder == null)
                {
                    leftEnterTheSelectedFolder = new RelayCommand(
                        x => LeftEnterFile(),
                        x => true
                        );
                }
                return leftEnterTheSelectedFolder;
            }
        }

        private ICommand rightEnterTheSelectedFolder = null;
        public ICommand RightEnterTheSelectedFolder
        {
            get
            {
                if (rightEnterTheSelectedFolder == null)
                {
                    rightEnterTheSelectedFolder = new RelayCommand(
                        x => RightEnterFile(),
                        x => true
                        );
                }
                return rightEnterTheSelectedFolder;
            }
        }
        #endregion

        public MiniTCViewModel()
        {
            left = new PanelModel();
            right = new PanelModel();
        }

        public void LeftEnterFile()
        {
            if (!left.EnterFile(leftSelectedFile)) 
            {
                var message = "You have not perrmision to open this folder.\nRun program as administrator.";
                MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            onPropertyChanged(nameof(LeftInsideOfFolder), nameof(LeftPath));
        }

        public void RightEnterFile()
        {
            if (!right.EnterFile(rightSelectedFile))
            {
                var message = "You have not perrmision to open this folder.\nRun program as administrator.";
                MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            onPropertyChanged(nameof(LeftInsideOfFolder), nameof(RightPath));
        }
    }
}
