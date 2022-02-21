namespace System.Collections.Generic
{
    public static class IDictionary_Extensions
    {
        public static void Set<K, V>(this IDictionary<K, V> dict, K k, V v)
        {
            if (dict.ContainsKey(k))
                dict[k] = v;
            else
                dict.Add(k, v);
        }

        public static V GetOrDefault<K, V>(this IDictionary<K, V> dict, K k) => dict.ContainsKey(k) ? dict[k] : default;
    }
}
