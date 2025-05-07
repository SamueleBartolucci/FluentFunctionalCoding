using System;
using FluentAssertions;
using NUnit.Framework;
using FluentFunctionalCoding;

namespace FluentFunctionalCodingTest.FluentExtensions.ActionAsFunc.Extensions
{
    public class ActionAsFuncExtensionsTests
    {
        [Test]
        public void AsFunc_Action_ReturnsFuncReturningNothing()
        {
            bool called = false;
            System.Action act = () => called = true;
            var func = act.AsFunc();
            var result = func();
            called.Should().BeTrue();
            result.Should().Be(Nothing.SoftNull);
        }

        [Test]
        public void AsFunc_Action1_ReturnsFuncReturningNothing()
        {
            int value = 0;
            Action<int> act = x => value = x;
            var func = act.AsFunc();
            var result = func(42);
            value.Should().Be(42);
            result.Should().Be(Nothing.SoftNull);
        }

        [Test]
        public void AsFunc_Action2_ReturnsFuncReturningNothing()
        {
            int a = 0, b = 0;
            Action<int, int> act = (x, y) => { a = x; b = y; };
            var func = act.AsFunc();
            var result = func(1, 2);
            a.Should().Be(1);
            b.Should().Be(2);
            result.Should().Be(Nothing.SoftNull);
        }

        [Test]
        public void AsFunc_Action3_ReturnsFuncReturningNothing()
        {
            int a = 0, b = 0, c = 0;
            Action<int, int, int> act = (x, y, z) => { a = x; b = y; c = z; };
            var func = act.AsFunc();
            var result = func(1, 2, 3);
            a.Should().Be(1);
            b.Should().Be(2);
            c.Should().Be(3);
            result.Should().Be(Nothing.SoftNull);
        }
    }
}
