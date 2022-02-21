namespace System.Collections.Generic
{
    public static class IEnumerable_Extensions
    {
        public static IEnumerable<T> Padding<T>(this IEnumerable<T> source, int n, T defa = default)
        {
            int i = 0;
            foreach (var v in source)
            {
                if (i >= n)
                    break;

                yield return v;

                i++;
            }

            for (; i < n; i++)
            {
                yield return defa;
            }
        }
    }
}
