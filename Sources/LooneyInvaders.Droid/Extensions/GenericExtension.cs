using System;
using System.Threading.Tasks;
using Android.App;

namespace LooneyInvaders.Droid.Extensions
{
    public static class GenericExtension
    {
        public static TResult WithAction<TResult>(this TResult obj, Action<TResult> action)
        {
            action?.Invoke(obj);

            return obj;
        }

        public async static Task RunOnUiThreadAsync(this Activity activity, Action action)
        {
            await Task.Run(() => activity.RunOnUiThread(action));
        }
    }
}
