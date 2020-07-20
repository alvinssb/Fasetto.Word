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

        protected bool _searchIsOpen;

        protected string _searchText;

        protected string _lastSearchText;

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

        public string PendingMessageText { get; set; }

        public bool SearchIsOpen
        {
            get => _searchIsOpen;
            set
            {
                if (_searchIsOpen == value)
                    return;
                _searchIsOpen = value;
                if (!_searchIsOpen)
                    SearchText = string.Empty;

            }
        }

        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText == value)
                    return;

                _searchText = value;

                if (string.IsNullOrEmpty(SearchText))
                    Search();
            }
        }

        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        #endregion

        #region Public Commands

        public ICommand AttachmentButtonCommand { get; set; }

        public ICommand PopupClickawayCommand { get; set; }

        public ICommand OpenSearchCommand { get; set; }

        public ICommand CloseSearchCommand { get; set; }

        public ICommand ClearSearchCommand { get; set; }

        public ICommand SearchCommand { get; set; }

        public ICommand SendCommand { get; set; }

        #endregion

        public ChatMessageListViewModel()
        {
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);
            PopupClickawayCommand = new RelayCommand(PopupClickaway);
            OpenSearchCommand = new RelayCommand(OpenSearch);
            CloseSearchCommand = new RelayCommand(CloseSearch);
            SearchCommand = new RelayCommand(Search);
            SendCommand = new RelayCommand(Send);
            ClearSearchCommand = new RelayCommand(ClearSearch);

            AttachmentMenu = new ChatAttachmentPopupMenuViewModel();
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

        public void Send()
        {
            if (string.IsNullOrEmpty(PendingMessageText))
                return;

            if(Items==null)
                Items=new ObservableCollection<ChatMessageListItemViewModel>();

            if(FilteredItems==null)
                FilteredItems=new ObservableCollection<ChatMessageListItemViewModel>();

            var message = new ChatMessageListItemViewModel
            {
                Initials = "LM",
                Message = PendingMessageText,
                MessageSentTime = DateTime.UtcNow,
                SentByMe = true,
                SenderName = "Luke Malpass",
                NewItem = true
            };
            Items.Add(message);
            FilteredItems.Add(message);

            PendingMessageText = string.Empty;
        }

        public void Search()
        {
            if (string.IsNullOrEmpty(_lastSearchText) && string.IsNullOrEmpty(SearchText) || string.Equals(_lastSearchText, SearchText))
                return;

            if (string.IsNullOrEmpty(SearchText) || Items == null || Items.Count == 0)
            {
                FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(Items ?? Enumerable.Empty<ChatMessageListItemViewModel>());
                _lastSearchText = SearchText;
                return;
            }

            FilteredItems = new ObservableCollection<ChatMessageListItemViewModel>(Items.Where(item => item.Message.ToLower().Contains(SearchText)));
            _lastSearchText = SearchText;
        }

        public void OpenSearch() => SearchIsOpen = true;

        public void CloseSearch() => SearchIsOpen = false;

        public void ClearSearch()
        {
            if (!string.IsNullOrEmpty(SearchText))
                SearchText = string.Empty;
            else
                SearchIsOpen = false;
        }

        #endregion
    }
}
