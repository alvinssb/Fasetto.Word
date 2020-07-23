using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    public class TextEntryViewModel : BaseViewModel
    {
        #region Public Properties

        public string Label { get; set; }

        public string OriginalText { get; set; }

        public string EditedText { get; set; }

        public bool Working { get; set; }

        public bool Editing { get; set; }

        public Func<Task<bool>> CommitAction { get; set; }

        #endregion

        #region Public Commands

        public ICommand EditCommand { get; set; }

        public ICommand SaveCommand { get; set; }

        public ICommand CancelCommand { get; set; }

        #endregion

        #region Command Methods

        public void Edit()
        {
            EditedText = OriginalText;
            Editing = true;
        }

        public void Cancel()
        {
            Editing = false;
        }

        public void Save()
        {
            var result = default(bool);
            var currentSavedValue = OriginalText;

            RunCommandAsync(() => Working, async () =>
            {
                Editing = false;
                OriginalText = EditedText;

                result = CommitAction == null || await CommitAction();
            }).ContinueWith(t =>
            {
                if (!result)
                {
                    OriginalText = currentSavedValue;
                    Editing = true;
                }
            });
        }

        #endregion

        public TextEntryViewModel()
        {
            EditCommand = new RelayCommand(Edit);
            SaveCommand = new RelayCommand(Save);
            CancelCommand = new RelayCommand(Cancel);
        }
    }
}
