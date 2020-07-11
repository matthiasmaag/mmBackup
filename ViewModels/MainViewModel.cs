using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace mmBackup.ViewModels
{
    internal class MainViewModel : Screen
    {
        #region private fields

        private IWindowManager _windowManager;

        #endregion private fields

        public MainViewModel()
        {
            _windowManager = new WindowManager();
        }

        protected override void OnActivate()
        {
            base.OnActivate();
        }

        #region properties

        public override string DisplayName
        {
            get
            {
                return "MainView";
            }
        }

        #endregion properties

        #region private methods

        // include private methods here

        #endregion private methods
    }
}
