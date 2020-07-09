namespace Fasetto.Word.Core
{
    public class ChatListItemViewModel:BaseViewModel
    {
        #region Public Properties

        public string Name { get; set; }

        public string Message { get; set; }

        public string Initials { get; set; }

        public string ProfilePictureRGB { get; set; }

        public bool NewContentAvailable { get; set; }

        public bool IsSelected { get; set; }

        #endregion
    }
}
