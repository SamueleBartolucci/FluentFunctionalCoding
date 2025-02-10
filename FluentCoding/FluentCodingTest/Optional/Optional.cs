using FluentAssertions;
using FluentCoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCodingTest.Optional.Init
{
    internal class Optional
    {

        [Test]
        public void Some_IsSome_True_IsNone_False()
        {
            var optionalString = "test".ToOptional();
            optionalString.IsSome.Should().BeTrue();
            optionalString.IsNone.Should().BeFalse();
        }


        [Test]
        public void Some_IsSome_False_IsNone_True()
        {
            string nullString = null;
            var optionalString = nullString.ToOptional();
            optionalString.IsSome.Should().BeFalse();
            optionalString.IsNone.Should().BeTrue();
        }

        [Test]
        public void None_IsSome_False_IsNone_True()
        {            
            var optionalString = Optional<string>.None();
            optionalString.IsSome.Should().BeFalse();
            optionalString.IsNone.Should().BeTrue();
        }
    }
}
