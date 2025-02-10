using FluentAssertions;
using FluentCoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCodingTest.Optional.Map
{
    internal class Optional
    {
        public int TestParse(string intString) => int.Parse(intString);
        public string TestNoneMap() => "none-test";


       

        [Test]
        public void Some_Map_NewType()
        {            
            var optionalString = "1433".ToOptional();
            var mappedOptional = optionalString.Map(TestParse);            
            mappedOptional.Should().BeOfType<OptionalJust<int>>();
            (mappedOptional as OptionalJust<int>)._value.Should().Be(1433);
        }

        [Test]
        public void None_Map_NewType()
        {
            var optionalString = Optional<string>.None();
            var mappedOptional = optionalString.Map(TestParse);            
            mappedOptional.Should().BeOfType<OptionalNone<int>>();
        }

        [Test]
        public void Some_MapNone()
        {
            var optionalString = "1433".ToOptional();
            var mappedOptional = optionalString.MapNone(TestNoneMap);
            mappedOptional.Should().BeOfType<OptionalJust<string>>();
            (mappedOptional as OptionalJust<string>)._value.Should().Be("1433");
        }

        [Test]
        public void None_MapNone()
        {
            var optionalString = Optional<string>.None();
            var mappedOptional = optionalString.MapNone(TestNoneMap);
            mappedOptional.Should().BeOfType<OptionalJust<string>>();
            (mappedOptional as OptionalJust<string>)._value.Should().Be("none-test");
        }
    }
}
