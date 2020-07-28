using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Fasetto.Word.Core;
using static Fasetto.Word.DI;

namespace Fasetto.Word
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
                ViewModelApplication.GoToPage(ApplicationPage.Login,new LoginViewModel
                {
                    Email = "jess@helloword.com"
                });
                return;
            }

            ViewModelApplication.GoToPage(ApplicationPage.Chat,new ChatMessageListViewModel
            {
                DisplayTitle = "Parnell, Me",
                Items = new ObservableCollection<ChatMessageListItemViewModel>
                {
                    new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Luke",
                        SentByMe = true,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A received message",
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Parnell",
                        SentByMe = false,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A received message",
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Parnell",
                        SentByMe = false,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = Message,
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF00FF",
                        SenderName = "Luke",
                        SentByMe = true,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A received message",
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Parnell",
                        SentByMe = false,
                    },
                    new ChatMessageListItemViewModel
                    {
                        Message = "A received message",
                        Initials = Initials,
                        MessageSentTime = DateTime.UtcNow,
                        ProfilePictureRGB = "FF0000",
                        SenderName = "Parnell",
                        SentByMe = false,
                    },
                }
            });
        }

        #endregion
    }
}
