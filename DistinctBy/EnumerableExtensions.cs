using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistinctBy
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Returns all elements from <paramref name="source"/> for which the
        /// key returned by <paramref name="keySelector"/> is unique.
        /// Preserves original ordering.
        /// </summary>
        public static IEnumerable<TSource> DistinctByCustom<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            IEqualityComparer<TKey>? comparer = null)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            var seenKeys = new HashSet<TKey>(comparer);
            foreach (var element in source)
            {
                var key = keySelector(element);
                if (seenKeys.Add(key))
                {
                    // first time we see this key ⇒ yield the element
                    yield return element;
                }
            }
        }
    }
}
