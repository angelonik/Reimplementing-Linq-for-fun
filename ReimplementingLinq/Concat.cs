using System;
using System.Collections.Generic;

namespace ReimplementingLinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<TSource> Concat<TSource>(
            this IEnumerable<TSource> first,
            IEnumerable<TSource> second)
        {
            return ConcatImpl(
                first ?? throw new ArgumentNullException(nameof(first)), 
                second ?? throw new ArgumentNullException(nameof(second)));
        }

        private static IEnumerable<TSource> ConcatImpl<TSource>(
            IEnumerable<TSource> first,
            IEnumerable<TSource> second)
        {
            foreach (TSource item in first)
            {
                yield return item;
            }

            // Avoid hanging onto a reference we don’t really need 
            first = null;
            foreach (TSource item in second)
            {
                yield return item;
            }
        }
    }

}
