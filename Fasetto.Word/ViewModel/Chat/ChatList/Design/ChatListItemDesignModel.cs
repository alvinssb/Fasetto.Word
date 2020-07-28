namespace Fasetto.Word
{
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
        #region Singleton

        public static ChatListItemDesignModel Instance => new ChatListItemDesignModel();

        #endregion


        #region Constructor

        public ChatListItemDesignModel()
        {
            Name = "Luke";
            Message = "This new chat app is awesome! I bet it willbe fast too";
            Initials = "LM";
            ProfilePictureRGB = "3099c5";
        }

        #endregion


    }
}
