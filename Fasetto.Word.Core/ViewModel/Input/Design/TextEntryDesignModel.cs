

namespace Fasetto.Word.Core
{
    public class TextEntryDesignModel : TextEntryViewModel
    {
        public static TextEntryDesignModel Instance => new TextEntryDesignModel();

        public TextEntryDesignModel()
        {
            Label = "Name";
            OriginalText = "Luke Malpass";
            EditedText = "Editing :)";
        }
    }
}
