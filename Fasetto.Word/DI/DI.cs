using Dna;
using Fasetto.Word.Core;

namespace Fasetto.Word
{
    public static class DI
    {
        public static ApplicationViewModel ViewModelApplication => Framework.Service<ApplicationViewModel>();

        public static SettingsViewModel ViewModelSettings => Framework.Service<SettingsViewModel>();
    }
}
