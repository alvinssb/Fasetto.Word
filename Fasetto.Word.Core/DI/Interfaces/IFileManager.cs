﻿
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    public interface IFileManager
    {
        Task WriteTextToFileAsync(string text, string path, bool append = false);

        string NormalizePath(string path);

        string ResolvePath(string path);
    }
}
