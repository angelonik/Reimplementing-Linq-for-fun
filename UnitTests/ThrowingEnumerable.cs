using System;
using System.Collections.Generic;
using System.Collections;
using Xunit;

namespace UnitTests
{
    /// <summary>
    /// Class to help for deferred execution tests: it throw an exception
    /// if GetEnumerator is called.
    /// </summary>
    internal sealed class ThrowingEnumerable : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator() => throw new InvalidOperationException();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Check that the given function uses deferred execution.
        /// A "spiked" source is given to the function: the function
        /// call itself shouldn't throw an exception. However, using
        /// the result (by calling GetEnumerator() then MoveNext() on it) *should*
        /// throw InvalidOperationException.
        /// </summary>
        internal static void AssertDeferred<T>(
            Func<IEnumerable<int>, IEnumerable<T>> deferredFunction)
        {
            var source = new ThrowingEnumerable();
            var result = deferredFunction(source);
            using (var iterator = result.GetEnumerator())
            {
                Assert.Throws<InvalidOperationException>(() => iterator.MoveNext());
            }
        }
    }
}
