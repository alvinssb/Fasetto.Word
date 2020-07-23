
namespace Fasetto.Word.Core
{
    public class PasswordEntryDesignModel : PasswordEntryViewModel
    {
        public static PasswordEntryDesignModel Instance => new PasswordEntryDesignModel();

        public PasswordEntryDesignModel()
        {
            Label = "Name";
            FakePassword = "******";
        }
    }
}
