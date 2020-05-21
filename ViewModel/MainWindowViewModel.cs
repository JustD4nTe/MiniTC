using MiniTC.Models;
using MiniTC.ViewModel.BaseClass;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;

using resource = MiniTC.Properties.Resources;

namespace MiniTC.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        #region prop
        public PanelTCViewModel left { get; private set; }
        public PanelTCViewModel right { get; private set; }

        private PanelTCViewModel currentPanel;

        private IFileManager fileManager;
        #endregion

        #region Command
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
        #endregion

        public MainWindowViewModel()
        {
            left = new PanelTCViewModel();
            right = new PanelTCViewModel();

            left.PanelGotFocus += LeftGotFocus;
            right.PanelGotFocus += RightGotFocus;

            currentPanel = null;

            fileManager = new FileManager();
        }

        private void LeftGotFocus()
        => currentPanel = left;

        private void RightGotFocus()
        => currentPanel = right;

        private void CopyFiles()
        {
            if (currentPanel == left)
            {
                fileManager.Copy(left.CurrentPath, left.SelectedFile, right.CurrentPath);
                right.FolderInsideRefresh();
            }
            else
            {
                fileManager.Copy(right.CurrentPath, right.SelectedFile, left.CurrentPath);
                left.FolderInsideRefresh();
            }
        }
    }
}
