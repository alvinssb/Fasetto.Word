using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Dna;
using static Dna.FrameworkDI;

namespace Fasetto.Word.Core
{
    public static class AsyncAwaiter
    {
        #region Private Members

        private static SemaphoreSlim _selfLock=new SemaphoreSlim(1,1);

        private static Dictionary<string,SemaphoreSlim> _semaphores=new Dictionary<string, SemaphoreSlim>();

        #endregion

        public static async Task AwaitAsync(string key, Func<Task> task, int maxAccessCount = 1)
        {
            await _selfLock.WaitAsync();

            try
            {
                if (!_semaphores.ContainsKey(key))
                    _semaphores.Add(key, new SemaphoreSlim(maxAccessCount, maxAccessCount));
            }
            finally
            {
                _selfLock.Release();
            }

            var semaphore = _semaphores[key];
            await semaphore.WaitAsync();
            try
            {
                await task();
            }
            catch (Exception ex)
            {

                // Log message to debug level 
                // (may not be an issue but we don't want to miss anything in debug)
                Logger.LogDebugSource($"Crash in {nameof(AwaitAsync)}. {ex.Message}");

                // Break debugger
                Debugger.Break();

                // Bubble exception up as normal
                throw;
            }
            finally
            {
                semaphore.Release();
            }
        }
    }
}
