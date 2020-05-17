using MiniTC.Models;
using MiniTC.ViewModel.BaseClass;

namespace MiniTC.ViewModel
{
    class MiniTCViewModel : ViewModelBase
    {
        #region prop
        private MiniTCModel model;

        public string[] LogicalDrivers { 
            get { return model.LogicalDrivers; } 
        }

        #endregion

        public MiniTCViewModel()
        {
            model = new MiniTCModel();
        }
    }
}
