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

        private IPanelTC currentPanel;

        private IFileManager fileManager;

        public string[] LeftLogicalDrivers
        {
            get { return left.ListOfDrives; }
        }

        public string[] RightLogicalDrivers
        {
            get { return right.ListOfDrives; }
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

        private ICommand leftPanelGotFocus = null;
        public ICommand LeftPanelGotFocus
        {
            get
            {
                if (leftPanelGotFocus == null)
                {
                    leftPanelGotFocus = new RelayCommand(
                        x => currentPanel = left, x => true);
                }
                return leftPanelGotFocus;
            }
        }

        private ICommand rightPanelGotFocus = null;
        public ICommand RightPanelGotFocus
        {
            get
            {
                if (rightPanelGotFocus == null)
                {
                    rightPanelGotFocus = new RelayCommand(
                        x => currentPanel = right, x => true);
                }
                return rightPanelGotFocus;
            }
        }

        private ICommand copy = null;
        public ICommand Copy
        {
            get
            {
                if (copy == null)
                {
                    copy = new RelayCommand(x => CopyFiles(),
                                            x => true);
                }

                return copy;
            }
        }

        private ICommand leftGetLogicalDrives = null;
        public ICommand LeftGetLogicalDrives
        {
            get
            {
                if (leftGetLogicalDrives == null)
                {
                    leftGetLogicalDrives = new RelayCommand(
                        x => { left.UpdateLogicalDrives(); onPropertyChanged(nameof(LeftLogicalDrivers)); }, 
                        x => true
                        );
                }

                return leftGetLogicalDrives;
            }
        }

        private ICommand rightleftGetLogicalDrives = null;
        public ICommand RightGetLogicalDrives
        {
            get
            {
                if (rightleftGetLogicalDrives == null)
                {
                    rightleftGetLogicalDrives = new RelayCommand(
                        x => { right.UpdateLogicalDrives(); onPropertyChanged(nameof(RightLogicalDrivers)); }, 
                        x => true
                        );
                }

                return rightleftGetLogicalDrives;
            }
        }
        #endregion

        public MiniTCViewModel()
        {
            left = new PanelModel();
            right = new PanelModel();

            currentPanel = null;

            fileManager = new FileManager();
        }

        private void LeftEnterFile()
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

        private void RightEnterFile()
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

        private void CopyFiles()
        {
            var from = currentPanel == left ? left : right;
            var to = currentPanel == left ? right : left;
            var selectedFile = currentPanel == left ? leftSelectedFile : rightSelectedFile;

            fileManager.Copy(from.CurrentPath, selectedFile, to.CurrentPath);
        }
    }
}
