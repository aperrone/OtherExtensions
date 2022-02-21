namespace System.Collections.Generic
{
    public static class IList_Extensions
    {
        public static void AddSorted<T>(this IList<T> list, T item, Comparison<T> comparison)
        {
            AddSorted<T>(list, item, Comparer<T>.Create(comparison));
        }

        public static void AddSorted<T>(this IList<T> list, T item, IComparer<T> comparer = null)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            comparer = comparer ?? Comparer<T>.Default;

            if (list.Count == 0)
            {
                list.Add(item);
                return;
            }

            if (comparer.Compare(list[list.Count - 1], item) <= 0)
            {
                list.Add(item);
                return;
            }

            if (comparer.Compare(list[0], item) >= 0)
            {
                list.Insert(0, item);
                return;
            }

            int index = list.BinarySearchIndexOf(item, comparer);
            if (index < 0)
                index = ~index;
            list.Insert(index, item);
        }

        public static int BinarySearchIndexOf<T>(this IList<T> list, T value, IComparer<T> comparer = null)
        {
            if (list == null)
                throw new ArgumentNullException(nameof(list));

            comparer = comparer ?? Comparer<T>.Default;

            int lower = 0;
            int upper = list.Count - 1;

            while (lower <= upper)
            {
                int middle = lower + ((upper - lower) / 2);
                int comparisonResult = comparer.Compare(value, list[middle]);

                if (comparisonResult == 0)
                    return middle;
                else if (comparisonResult < 0)
                    upper = middle - 1;
                else
                    lower = middle + 1;
            }

            return ~lower;
        }
    }
}
