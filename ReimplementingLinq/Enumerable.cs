using System.Collections.Generic;

namespace ReimplementingLinq
{
    public static partial class Enumerable
    {
        public static IEnumerable<T> Empty<T>() => System.Linq.Enumerable.Empty<T>();
    }
}
