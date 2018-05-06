using FluentAssertions;
using ReimplementingLinq;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class WhereShould
    {
        [Fact]
        public void Throw_ArgumentException_when_source_is_null()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Where(x => x > 5));
        }

        [Fact]
        public void Throw_ArgumentException_when_predicate_is_null()
        {
            int[] source = { 1, 3, 7, 9, 10 };
            Func<int, bool> predicate = null;
            Assert.Throws<ArgumentNullException>(() => source.Where(predicate));
        }

        [Fact]
        public void Throw_ArgumentException_when_source_is_null_and_index_provided()
        {
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(() => source.Where((x, index) => x > 5));
        }

        [Fact]
        public void Throw_ArgumentException_when_predicate_with_index_is_null()
        {
            int[] source = { 1, 3, 7, 9, 10 };
            Func<int, int, bool> predicate = null;
            Assert.Throws<ArgumentNullException>(() => source.Where(predicate));
        }

        [Fact]
        public void Do_simple_filtering()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result = source.Where(x => x < 4);
            result.Should().BeEquivalentTo(new int[] { 1, 3, 2, 1 });
        }

        [Fact]
        public void Do_filtering_for_query_expression()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result = from x in source
                         where x < 4
                         select x;
            result.Should().BeEquivalentTo(new int[] { 1, 3, 2, 1 });
        }

        [Fact]
        public void Return_empty_when_source_is_empty()
        {
            var source = Enumerable.Empty<int>();
            var result = source.Where(x => x < 4);
            result.Should().BeEmpty();
        }

        [Fact]
        public void Have_deffered_execution()
        {
            ThrowingEnumerable.AssertDeferred(src => src.Where(x => x > 0));
        }

        [Fact]
        public void Do_filtering_when_index_is_provided()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result = source.Where((x, index) => x < index);
            result.Should().BeEquivalentTo(new int[] { 2, 1 });
        }

        [Fact]
        public void Return_empty_when_source_is_empty_and_index_provided()
        {
            var source = Enumerable.Empty<int>();
            var result = source.Where((x, index) => x < 4);
            result.Should().BeEmpty();
        }

        [Fact]
        public void Have_deffered_execution_when_index_provided()
        {
            ThrowingEnumerable.AssertDeferred(src => src.Where((x, index) => x > 0));
        }
    }
}
