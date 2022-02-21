using System;
using System.Linq;

namespace System
{
    public static class Array_Extensions
    {
        public static TOutput[] ConvertAll<T, TOutput>(this T[] input, Converter<T, TOutput> converter)
        {
            if (converter is null)
                throw new ArgumentNullException(nameof(converter));

            return input.Select(v => converter(v)).ToArray();
        }
    }
}
