using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasetto.Word
{
    public class SettingsViewModel : BaseViewModel
    {
        #region Public Properties

        public TextEntryViewModel FirstName { get; set; }

        public TextEntryViewModel LastName { get; set; }

        public TextEntryViewModel Username { get; set; }

        public PasswordEntryViewModel Password { get; set; }

        public TextEntryViewModel Email { get; set; }

        public string LogoutButtonText { get; set; }

        #endregion

        #region Public Commands

        public ICommand LogoutCommand { get; set; }

        #endregion

        public SettingsViewModel()
        {
            LogoutButtonText = "Logout";
        }

        #region Command Methods

        public async Task LoadAsync()
        {

        }

        #endregion
    }
}
