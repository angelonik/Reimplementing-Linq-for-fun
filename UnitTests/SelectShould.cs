using FluentAssertions;
using ReimplementingLinq;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class SelectShould
    {
        [Fact]
        public void Project_to_different_type()
        {
            int[] source = { 1, 5, 2 };
            var result = source.Select(x => x.ToString());
            result.Should().BeEquivalentTo("1", "5", "2");
        }

        [Fact]
        public void WhereAndSelect()
        {
            int[] source = { 1, 3, 4, 2, 8, 1 };
            var result = from x in source
                         where x < 4
                         select x * 2;
            result.Should().BeEquivalentTo(new int[] { 2, 6, 4, 2 });
        }
    }
}
