using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static Fasetto.Word.Core.CoreDI;

namespace Fasetto.Word.Core
{
    public class BaseFileManager : IFileManager
    {
        public async Task WriteTextToFileAsync(string text, string path, bool append = false)
        {
            path = NormalizePath(path);
            path = ResolvePath(path);

            await AsyncAwaiter.AwaitAsync(nameof(BaseFileManager) + path, async () =>
            {
                await TaskManager.Run(() =>
                {
                    using (var fileStream = (TextWriter) new StreamWriter(File.Open(path, append ? FileMode.Append : FileMode.Create)))
                        fileStream.Write(text);
                });
            });
        }

        public string NormalizePath(string path)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                return path?.Replace('/', '\\').Trim();
            else
                return path?.Replace('\\', '/').Trim();
        }

        public string ResolvePath(string path)
        {
            return Path.GetFullPath(path);
        }
    }
}
