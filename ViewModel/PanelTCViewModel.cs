using MiniTC.Models;
using MiniTC.ViewModel.BaseClass;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

using resource = MiniTC.Properties.Resources;

namespace MiniTC.ViewModel
{
    class PanelTCViewModel : ViewModelBase
    {
        #region prop
        private IPanelTC model;

        public string CurrentPath => model.CurrentPath;
        public List<string> InsideOfFolder => model.FolderInside;

        private string[] logicalDrives;
        public string[] LogicalDrives => logicalDrives;

        private string selectedDrive;
        public string SelectedDrive
        {
            get { return selectedDrive; }
            set
            {
                if (value != null)
                {
                    selectedDrive = value;
                    model.SetFoldersAndFilesOfCurrentFolder(selectedDrive);
                    onPropertyChanged(nameof(SelectedDrive), nameof(InsideOfFolder), nameof(CurrentPath));
                }
            }
        }

        private string selectedFile;
        public string SelectedFile
        {
            get { return selectedFile; }
            set { selectedFile = value; }
        }

        public delegate void foo();
        public event foo PanelGotFocus;
        #endregion

        #region Command
        private ICommand enterTheSelectedFolder = null;
        public ICommand EnterTheSelectedFolder
        {
            get
            {
                if (enterTheSelectedFolder == null)
                {
                    enterTheSelectedFolder = new RelayCommand(
                        x => EnterFile(),
                        x => true
                        );
                }
                return enterTheSelectedFolder;
            }
        }

        private ICommand getLogicalDrives = null;
        public ICommand GetLogicalDrives
        {
            get
            {
                if (getLogicalDrives == null)
                {
                    getLogicalDrives = new RelayCommand(
                        x => { logicalDrives = model.ListOfDrives; onPropertyChanged(nameof(LogicalDrives)); },
                        x => true
                        );
                }

                return getLogicalDrives;
            }
        }

        private ICommand focused = null;
        public ICommand Focused
        {
            get
            {
                if (focused == null)
                {
                    focused = new RelayCommand(x => PanelGotFocus(),
                                               x => true);
                }
                return getLogicalDrives;
            }
        }
        #endregion

        public PanelTCViewModel()
        {
            model = new PanelModel();
        }

        public void FolderInsideRefresh()
        {
            model.SetFoldersAndFilesOfCurrentFolder(model.CurrentPath);
            onPropertyChanged(nameof(InsideOfFolder));
        }

        private void EnterFile()
        {
            if (!model.EnterFile(selectedFile))
            {
                MessageBox.Show(resource.PerrmissionError,
                                resource.Error,
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            else
            {
                onPropertyChanged(nameof(InsideOfFolder), nameof(CurrentPath));
            }
        }
    }
}
