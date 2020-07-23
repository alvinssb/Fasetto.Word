using System.Windows.Input;
using Fasetto.Word;

namespace Fasetto.Word.Core
{
    public class ChatListItemViewModel : BaseViewModel
    {
        #region Public Properties

        public string Name { get; set; }

        public string Message { get; set; }

        public string Initials { get; set; }

        public string ProfilePictureRGB { get; set; }

        public bool NewContentAvailable { get; set; }

        public bool IsSelected { get; set; }

        #endregion

        #region Public Commands

        public ICommand OpenMessageCommand { get; set; }

        #endregion

        public ChatListItemViewModel()
        {
            OpenMessageCommand=new RelayCommand(OpenMessage);
        }

        #region Command Methods

        public void OpenMessage()
        {
            if (Name == "Jesse")
            {
            }
        }

        #endregion
    }
}
