using System;
using FluentAssertions;
using NUnit.Framework;
using FluentFunctionalCoding;

namespace FluentFunctionalCodingTest.FluentExtensions.Misc
{
    public class FuncApplyExtensionsTests
    {
        [Test]
        public void Apply_Func1_ReturnsParameterlessFunc()
        {
            Func<int, int> func = x => x + 1;
            var applied = func.Apply(5);
            applied().Should().Be(6);
        }

        [Test]
        public void Apply_Func2_ReturnsFuncWithOneParameter()
        {
            Func<int, int, int> func = (x, y) => x + y;
            var applied = func.Apply(3);
            applied(4).Should().Be(7);
        }

        [Test]
        public void Apply_Func3_ReturnsFuncWithTwoParameters()
        {
            Func<int, int, int, int> func = (x, y, z) => x + y + z;
            var applied = func.Apply(1);
            applied(2, 3).Should().Be(6);
        }
    }
}
