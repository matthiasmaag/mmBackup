using System.Collections.Generic;
using Caliburn.Micro;

namespace mmBackup.ViewModels
{
    public class ShellViewModel : PropertyChangedBase
    {
        private Screen _currentPageViewModel;
        private List<Screen> _pageViewModels;
        private IWindowManager _windowManager;

        public ShellViewModel()
        {
            _pageViewModels = new List<Screen>();
            _pageViewModels.Add(new MainViewModel());
            _currentPageViewModel = _pageViewModels[0];

            _windowManager = new WindowManager();
        }

        public Screen CurrentPageViewModel
        {
            get
            { return _currentPageViewModel; }
            set
            {
                _currentPageViewModel = value;
                NotifyOfPropertyChange(() => CurrentPageViewModel);
            }
        }

        #region Eventhandler

        public bool CanMainViewBtn
        {
            get
            {
                return true;
            }
        }

        public void MainViewBtn()
        {
            CurrentPageViewModel = _pageViewModels.Find(x => x.DisplayName == "MainView");
        }

        #endregion Eventhandler

        #region private Methods

        // include private methods here

        #endregion private Methods
    }
}