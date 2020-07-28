using System.Threading.Tasks;
using System.Windows.Input;
using Fasetto.Word.Core;
using static Fasetto.Word.DI;

namespace Fasetto.Word
{
    public class RegisterViewModel:BaseViewModel
    {
        #region Public Properties

        public string Email { get; set; }

        public string Password { get; set; }

        public bool RegisterIsRunning { get; set; }

        #endregion

        #region Commands

        public ICommand LoginCommand { get; set; }

        public ICommand RegisterCommand { get; set; }

        #endregion

        #region Constructor

        public RegisterViewModel()
        {
            RegisterCommand=new RelayCommand(async ()=>await RegisterAsync());
            LoginCommand=new RelayCommand(async ()=>await LoginAsync());
        }

        #endregion

        public async Task RegisterAsync()
        {
            await RunCommandAsync(() => RegisterIsRunning, async () =>
            {
                await Task.Delay(5000);
            });
        }

        public async Task LoginAsync()
        {
            await Task.Delay(1);
            ViewModelApplication.GoToPage(ApplicationPage.Login);
        }
    }
}
