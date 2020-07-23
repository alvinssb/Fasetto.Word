
namespace Fasetto.Word.Core
{
    public class ApplicationViewModel : BaseViewModel
    {
        #region Public Properties

        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;

        public bool SideMenuVisible { get; set; }

        #endregion


        public void GoToPage(ApplicationPage page)
        {
            CurrentPage = page;

            SideMenuVisible = page == ApplicationPage.Chat;
        }
    }
}
