using FluentAssertions;
using FluentCoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCodingTest.Optional.Preludes
{
    internal class Optional
    {
        [Test]
        public void SomeFromValue()
        { 
            string nonNullObject = "test";
            var someOfObject = nonNullObject.Some();
            someOfObject.Should().BeOfType<OptionalJust<string>>();                
            (someOfObject as OptionalJust<string>)._value.Should().Be(nonNullObject);
        }

        [Test]
        public void SomeFromNull()
        {
            string nullObject = null;
            nullObject.Some().Should().BeOfType<OptionalNone<string>>();
        }
    }
}
