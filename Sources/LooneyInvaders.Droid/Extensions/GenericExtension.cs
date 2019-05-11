using System;

namespace LooneyInvaders.Droid.Extensions
{
    public static class GenericExtension
    {
        public static TResult WithAction<TResult>(this TResult obj, Action action)
        {
            action?.Invoke();

            return obj;
        }
    }
}
