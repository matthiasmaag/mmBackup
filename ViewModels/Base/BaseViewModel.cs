using Caliburn.Micro;

namespace mmBackup.ViewModels.Base
{
    public abstract class BaseViewModel:Screen, IMenu
    {
        public abstract void New();
    }
}