using System.Collections.Generic;
using System.Windows;
using Caliburn.Micro;
using mmBackup.ViewModels.Base;

namespace mmBackup.ViewModels
{
    public class ShellViewModel : PropertyChangedBase
    {
        private BaseViewModel _currentPageViewModel;
        private List<BaseViewModel> _pageViewModels;
        private IWindowManager _windowManager;

        public ShellViewModel()
        {
            _pageViewModels = new List<BaseViewModel>();
            _pageViewModels.Add(new MainViewModel());
            _currentPageViewModel = _pageViewModels[0];

            _windowManager = new WindowManager();
        }

        public BaseViewModel CurrentPageViewModel
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

        public void Exit()
        {
            Application.Current.Shutdown();
        }

        public void New()
        {
            CurrentPageViewModel = _pageViewModels.Find(x => x.DisplayName == "MainView");
            CurrentPageViewModel.New();
        }

        #endregion Eventhandler

        #region private Methods

        // include private methods here

        #endregion private Methods
    }
}