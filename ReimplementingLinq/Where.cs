using System;
using System.Collections.Generic;

namespace ReimplementingLinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<T> Where<T>(
            this IEnumerable<T> source,
            Func<T, bool> predicate)
        {
            return WhereImpl(
                source ?? throw new ArgumentNullException(nameof(source)),
                predicate ?? throw new ArgumentNullException(nameof(predicate)));
        }

        private static IEnumerable<T> WhereImpl<T>(
            IEnumerable<T> source,
            Func<T, bool> predicate)
        {
            foreach (T item in source)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<T> Where<T>(
            this IEnumerable<T> source,
            Func<T, int, bool> predicate)
        {
            return WhereImpl(
                source ?? throw new ArgumentNullException(nameof(source)),
                predicate ?? throw new ArgumentNullException(nameof(predicate)));
        }

        private static IEnumerable<TSource> WhereImpl<TSource>(
            this IEnumerable<TSource> source,
            Func<TSource, int, bool> predicate)
        {
            int index = 0;
            foreach (TSource item in source)
            {
                if (predicate(item, index))
                {
                    yield return item;
                }
                index++;
            }
        }
    }

}
