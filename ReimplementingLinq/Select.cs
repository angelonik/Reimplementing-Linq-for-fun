using System;
using System.Collections.Generic;
using System.Text;

namespace ReimplementingLinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            return SelectImpl(
                source ?? throw new ArgumentNullException(nameof(source)),
                selector ?? throw new ArgumentNullException(nameof(selector)));
        }

        private static IEnumerable<TResult> SelectImpl<TSource, TResult>(
            IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            foreach (TSource item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(
            this IEnumerable<TSource> source,
            Func<TSource, int, TResult> selector)
        {
            return SelectImpl(
                source ?? throw new ArgumentNullException(nameof(source)),
                selector ?? throw new ArgumentNullException(nameof(selector)));
        }

        private static IEnumerable<TResult> SelectImpl<TSource, TResult>(
            IEnumerable<TSource> source,
            Func<TSource, int, TResult> selector)
        {
            int index = 0;
            foreach (TSource item in source)
            {
                yield return selector(item, index);
                index++;
            }
        }
    }
}
