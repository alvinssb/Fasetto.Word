using Fasetto.Word.Core;
using static Fasetto.Word.DI;
using static Fasetto.Word.Core.CoreDI;

namespace Fasetto.Word
{
    public class ApplicationViewModel : BaseViewModel
    {

        #region Private Members

        private bool _settingsMenuVisible;

        #endregion

        #region Public Properties

        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;

        public BaseViewModel CurrentPageViewModel { get; set; }

        public bool SideMenuVisible { get; set; }

        public bool SettingsMenuVisible
        {
            get => _settingsMenuVisible;
            set
            {
                if (_settingsMenuVisible == value)
                    return;

                _settingsMenuVisible = value;
                if(value)
                    TaskManager.RunAndForget(ViewModelSettings.LoadAsync);
            }
        }

        #endregion


        public void GoToPage(ApplicationPage page,BaseViewModel viewModel=null)
        {
            SideMenuVisible = false;

            CurrentPageViewModel = viewModel;

            var different = CurrentPage != page;

            CurrentPage = page;

            if(!different)
                OnPropertyChanged(nameof(CurrentPage));

            SideMenuVisible = page == ApplicationPage.Chat;
        }
    }
}
