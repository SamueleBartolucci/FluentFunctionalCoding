using System;
using FluentAssertions;
using NUnit.Framework;
using FluentFunctionalCoding;

namespace FluentFunctionalCodingTest.FluentExtensions.Action.Apply.Extensions
{
    public class ActionApplyExtensionsTests
    {
        [Test]
        public void Apply_Action1_ReturnsParameterlessAction()
        {
            int result = 0;
            Action<int> act = x => result = x;
            var applied = act.Apply(5);
            applied();
            result.Should().Be(5);
        }

        [Test]
        public void Apply_Action2_ReturnsActionWithOneParameter()
        {
            int a = 0, b = 0;
            Action<int, int> act = (x, y) => { a = x; b = y; };
            var applied = act.Apply(7);
            applied(9);
            a.Should().Be(7);
            b.Should().Be(9);
        }

        [Test]
        public void Apply_Action3_ReturnsActionWithTwoParameters()
        {
            int a = 0, b = 0, c = 0;
            Action<int, int, int> act = (x, y, z) => { a = x; b = y; c = z; };
            var applied = act.Apply(1);
            applied(2, 3);
            a.Should().Be(1);
            b.Should().Be(2);
            c.Should().Be(3);
        }
    }
}
