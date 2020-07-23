
using Dna;
using Fasetto.Word.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Fasetto.Word
{
    public static class FrameworkConstructionExtensions
    {
        public static FrameworkConstruction AddFasettoWordViewModels(this FrameworkConstruction construction)
        {
            construction.Services.AddSingleton<ApplicationViewModel>();

            construction.Services.AddSingleton<SettingsViewModel>();

            return construction;
        }

        public static FrameworkConstruction AddFasettoWordClientServices(this FrameworkConstruction construction)
        {
            construction.Services.AddTransient<ITaskManager, BaseTaskManager>();

            return construction;
        }
    }
}
