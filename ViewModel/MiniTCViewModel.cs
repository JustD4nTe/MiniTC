using MiniTC.Models;
using MiniTC.ViewModel.BaseClass;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

using resource = MiniTC.Properties.Resources;

namespace MiniTC.ViewModel
{
    class MiniTCViewModel : ViewModelBase
    {
        #region prop
        private IPanelTC left;
        private IPanelTC right;

        public string[] LogicalDrivers
        {
            get { return left.ListOfDrives; }
        }

        public List<string> LeftInsideOfFolder
        {
            get { return left.FolderInside; }
        }

        public List<string> RightInsideOfFolder
        {
            get { return right.FolderInside; }
        }

        private string leftSelectedDrive;
        public string LeftSelectedDrive
        {
            get { return leftSelectedDrive; }
            set
            {
                if (value != null)
                {
                    leftSelectedDrive = value;
                    left.SetFoldersAndFilesOfCurrentFolder(leftSelectedDrive);
                    onPropertyChanged(nameof(LeftSelectedDrive), nameof(LeftInsideOfFolder), nameof(LeftPath));
                }
            }
        }


        private string rightSelectedDrive;
        public string RightSelectedDrive
        {
            get { return rightSelectedDrive; }
            set
            {
                if (value != null)
                {
                    rightSelectedDrive = value;
                    right.SetFoldersAndFilesOfCurrentFolder(rightSelectedDrive);
                    onPropertyChanged(nameof(RightSelectedDrive), nameof(RightInsideOfFolder), nameof(RightPath));
                }
            }
        }

        public string LeftPath
        {
            get { return left.CurrentPath; }
        }

        public string RightPath
        {
            get { return right.CurrentPath; }
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

            LeftSelectedDrive = left.ListOfDrives[0];
            RightSelectedDrive = right.ListOfDrives[0];
        }

        public void LeftEnterFile()
        {
            if (!left.EnterFile(leftSelectedFile))
            {
                MessageBox.Show(resource.PerrmissionError,
                                resource.Error,
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            else
            {
                onPropertyChanged(nameof(LeftInsideOfFolder), nameof(LeftPath));
            }
        }

        public void RightEnterFile()
        {
            if (!right.EnterFile(rightSelectedFile))
            {
                MessageBox.Show(resource.PerrmissionError,
                                resource.Error,
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            else
            {
                onPropertyChanged(nameof(RightInsideOfFolder), nameof(RightPath));
            }
        }
    }
}
