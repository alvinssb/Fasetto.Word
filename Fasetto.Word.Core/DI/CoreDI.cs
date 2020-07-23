using Dna;

namespace Fasetto.Word.Core
{
    public static class CoreDI
    {
        public static IFileManager FileManager => Framework.Service<IFileManager>();

        public static ITaskManager TaskManager => Framework.Service<ITaskManager>();
    }
}
