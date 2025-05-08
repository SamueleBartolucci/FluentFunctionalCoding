using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;
using FluentFunctionalCoding;
using System.Linq;

namespace FluentFunctionalCodingTest.FluentExtensions.Null.Extensions
{
    public class NullExtensionsTests
    {
        [Test]
        public void IsNull_ReturnsTrueIfNull()
        {
            object obj = null;
            obj.IsNull().Should().BeTrue();
        }

        [Test]
        public void IsNull_ReturnsFalseIfNotNull()
        {
            object obj = new object();
            obj.IsNull().Should().BeFalse();
        }

        [Test]
        public void IsNotNull_ReturnsTrueIfNotNull()
        {
            object obj = new object();
            obj.IsNotNull().Should().BeTrue();
        }

        [Test]
        public void IsNotNull_ReturnsFalseIfNull()
        {
            object obj = null;
            obj.IsNotNull().Should().BeFalse();
        }


        [Test]
        public void IsNullOrEmpty_String_ReturnsTrueIfNullOrEmpty()
        {
            string s1 = null;
            string s2 = "";
            s1.IsNullOrEmpty().Should().BeTrue();
            s2.IsNullOrEmpty().Should().BeTrue();
        }
        [Test]
        public void IsNotNullOrEmpty_String_ReturnsFalseIfNullOrEmpty()
        {
            string s1 = null;
            string s2 = "";
            s1.IsNotNullOrEmpty().Should().BeFalse();
            s2.IsNotNullOrEmpty().Should().BeFalse();
        }



        [Test]
        public void IsNullOrEmpty_String_ReturnsFalseIfNotEmpty()
        {
            "abc".IsNullOrEmpty().Should().BeFalse();
        }

        [Test]
        public void IsNotNullOrEmpty_String_ReturnsTrueIfNotEmpty()
        {
            "abc".IsNotNullOrEmpty().Should().BeTrue();
        }

        [Test]
        public void IsNullOrEmpty_Enumerable_ReturnsTrueIfNullOrEmpty()
        {
            List<int> list1 = null;
            List<int> list2 = new List<int>();
            list1.IsNullOrEmpty().Should().BeTrue();
            list2.IsNullOrEmpty().Should().BeTrue();
        }

        [Test]
        public void IsNotNullOrEmpty_Enumerable_ReturnsFalseIfNullOrEmpty()
        {
            List<int> list1 = null;
            List<int> list2 = new List<int>();
            list1.IsNotNullOrEmpty().Should().BeFalse();
            list2.IsNotNullOrEmpty().Should().BeFalse();
        }


        [Test]
        public void IsNullOrEmpty_Enumerable_ReturnsFalseIfNotEmpty()
        {
            var list = new List<int> { 1 };
            list.IsNullOrEmpty().Should().BeFalse();
        }


        [Test]
        public void IsNotNullOrEmpty_Enumerable_ReturnsTrueIfNotEmpty()
        {
            var list = new List<int> { 1 };
            list.IsNotNullOrEmpty().Should().BeTrue();
        }
    }
}
