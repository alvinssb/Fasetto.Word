using System.Security;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Fasetto.Word.Core;
using static Fasetto.Word.DI;

namespace Fasetto.Word
{
    public class LoginViewModel : BaseViewModel
    {
        #region Public Properties

        public string Email { get; set; }

        public SecureString Password { get; set; }

        public bool LoginIsRunning { get; set; }

        #endregion

        #region Commands

        public ICommand LoginCommand { get; set; }
        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Constructor

        public LoginViewModel()
        {
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await Login(parameter));
            RegisterCommand=new RelayCommand(async ()=>await Register());
        }

        #endregion

        public async Task Login(object parameter)
        {
            await RunCommandAsync(() => this.LoginIsRunning, async () =>
            {
                await Task.Delay(1000);
                ViewModelApplication.GoToPage(ApplicationPage.Chat);
            });
        }

        public async Task Register()
        {
            ViewModelApplication.GoToPage(ApplicationPage.Register);
            await Task.Delay(1);
        }
    }
}
