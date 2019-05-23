using System;
using System.Threading;
using System.Threading.Tasks;

namespace LooneyInvaders.Extensions
{
    public static class TaskCompletionSourceExtensions
    {
        public static Task<T> TaskWithTimeout<T>(
            this TaskCompletionSource<T> tcs, 
            CancellationToken cancellationToken,
            bool useSynchronizationContext = false)
        {
            cancellationToken.Register(() => tcs.TrySet(),
                useSynchronizationContext);
            return tcs.Task;
        }

        static bool TrySet<T>(this TaskCompletionSource<T> tcs, bool cancelled = true)
        {
            try
            {
                return cancelled
                    ? tcs.TrySetCanceled()
                    : tcs.Task != null
                        ? tcs.TrySetResult(tcs.Task.Result)
                        : default(bool);
            }
            catch
            {
                return default(bool);
            }
        }

        public static Task<TResult> TaskWithTimeout<TResult>(this TaskCompletionSource<TResult> tcs, TimeSpan timeout)
        {
            var timer = new Timer(state =>
                            ((TaskCompletionSource<TResult>)state).TrySetCanceled(),
                            tcs, timeout, TimeSpan.FromMilliseconds(-1));
            tcs.Task.ContinueWith(t =>
            {
                timer.Dispose();
                tcs.TrySetResult(t.Result);
            }, TaskContinuationOptions.ExecuteSynchronously);
            return tcs.Task;
        }
    }
}
