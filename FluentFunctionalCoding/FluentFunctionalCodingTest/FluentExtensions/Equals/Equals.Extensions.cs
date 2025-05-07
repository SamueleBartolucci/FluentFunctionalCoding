using System;
using FluentAssertions;
using NUnit.Framework;
using FluentFunctionalCoding;

namespace FluentFunctionalCodingTest.FluentExtensions.Equals
{
    public class EqualsExtensionsTests
    {
        [Test]
        public void EqualsToAny_DefaultEquality_ReturnsTrueIfMatchExists()
        {
            int subject = 5;
            subject.EqualsToAny(1, 2, 5, 7).Should().BeTrue();
        }

        [Test]
        public void EqualsToAny_DefaultEquality_ReturnsFalseIfNoMatch()
        {
            string subject = "foo";
            subject.EqualsToAny("bar", "baz").Should().BeFalse();
        }

        [Test]
        public void EqualsToAny_DefaultEquality_ReturnsFalseIfSubjectNull()
        {
            string subject = null;
            subject.EqualsToAny("a", "b").Should().BeFalse();
        }

        [Test]
        public void EqualsToAny_CustomComparer_ReturnsTrueIfMatchExists()
        {
            string subject = "abc";
            bool result = subject.EqualsToAny((s, v) => s.StartsWith(v), "a", "z");
            result.Should().BeTrue();
        }

        [Test]
        public void EqualsToAny_CustomComparer_ReturnsFalseIfNoMatch()
        {
            string subject = "abc";
            bool result = subject.EqualsToAny((s, v) => s.EndsWith(v), "x", "y");
            result.Should().BeFalse();
        }

        [Test]
        public void EqualsToAny_CustomComparer_ReturnsFalseIfSubjectNull()
        {
            string subject = null;
            bool result = subject.EqualsToAny((s, v) => s == v, "a", "b");
            result.Should().BeFalse();
        }
    }
}
