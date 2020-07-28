using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word
{
    public class ChatMessageListItemViewModel : BaseViewModel
    {
        #region Public Properties

        public string SenderName { get; set; }

        public string Message { get; set; }

        public string Initials { get; set; }

        public string ProfilePictureRGB { get; set; }

        public bool IsSelected { get; set; }

        public bool SentByMe { get; set; }

        public bool NewItem { get; set; }

        public DateTimeOffset MessageReadTime { get; set; }

        public DateTimeOffset MessageSentTime { get; set; }

        public bool MessageRead => MessageReadTime > DateTimeOffset.MinValue;

        #endregion
    }
}
