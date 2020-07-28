using static Fasetto.Word.DI;

namespace Fasetto.Word
{
    public class ViewModelLocator
    {
        #region Public Properties

        public static ViewModelLocator Instance { get; private set; }=new ViewModelLocator();

        public ApplicationViewModel ApplicationViewModel => ViewModelApplication;

        public SettingsViewModel SettingsViewModel => ViewModelSettings;

        #endregion
    }
}
