using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    public class ChatMessageListViewModel : BaseViewModel
    {
        #region Protected Members

        protected ObservableCollection<ChatMessageListItemViewModel> _items;

        #endregion

        #region Public Properties

        public ObservableCollection<ChatMessageListItemViewModel> Items
        {
            get => _items;
            set
            {
                if (_items == value)
                    return;
                _items = value;
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(_items);
            }
        }

        public ObservableCollection<ChatMessageListItemViewModel> FilteredItems { get; set; }

        public string DisplayTitle { get; set; }

        public bool AttachmentMenuVisible { get; set; }

        public bool AnyPopupVisible => AttachmentMenuVisible;

        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        #endregion

        #region Public Commands

        public ICommand AttachmentButtonCommand { get; set; }

        public ICommand PopupClickawayCommand { get; set; }

        #endregion

        public ChatMessageListViewModel()
        {
            AttachmentButtonCommand=new RelayCommand(AttachmentButton);
            PopupClickawayCommand=new RelayCommand(PopupClickaway);

            AttachmentMenu=new ChatAttachmentPopupMenuViewModel();
        }

        #region Command Methods

        public void AttachmentButton()
        {
            AttachmentMenuVisible ^= true;
        }

        public void PopupClickaway()
        {
            AttachmentMenuVisible = false;
        }

        #endregion
    }
}
