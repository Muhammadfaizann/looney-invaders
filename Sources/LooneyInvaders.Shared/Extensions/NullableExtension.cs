using System;

namespace LooneyInvaders.Extensions
{
    public static class NullableExtension
    {
        public static TValue Val<TValue>(this Nullable<TValue> value, TValue defaultValue = default(TValue))
            where TValue: struct
        {
            return value.GetValueOrDefault(defaultValue);
        }
    }
}
