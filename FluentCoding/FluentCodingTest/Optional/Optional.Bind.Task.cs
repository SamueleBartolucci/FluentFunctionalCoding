using FluentAssertions;
using FluentCoding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FluentCodingTest.Optional.BindTask
{
    internal class Optional
    {
        public Task<Optional<int>> FuncWithTaskOptionalResult(string s) => int.TryParse(s, out var result)
                                                                    .When()
                                                                    .IsTrue()
                                                                    .Match(@true => result.ToOptional(), @false => Optional<int>.None())
                                                                    .ToTask();

        public Task<Optional<string>> FuncTaskOptionalOnNone() => "none".ToOptional().ToTask();





        [Test]
        public void Some_Bind_TaskOptional()
        {

            var result = "1".ToOptional().BindAsync<int>(FuncWithTaskOptionalResult);
            result.Should().BeOfType<Task<Optional<int>>>();
            result.Result.Should().BeOfType<OptionalJust<int>>();
            (result.Result as OptionalJust<int>)._value.Should().Be(1);
        }

        [Test]
        public void Some_BindNone_TaskOptional()
        {

            var result = "1".ToOptional().BindNoneAsync(FuncTaskOptionalOnNone);
            result.Should().BeOfType<Task<Optional<string>>>();
            result.Result.Should().BeOfType<OptionalJust<string>>();
        }


        [Test]
        public void None_Bind_TaskOptional()
        {
            var result = Optional<string>.None().BindAsync(FuncWithTaskOptionalResult);
            result.Should().BeOfType<Task<Optional<int>>>();
            result.Result.Should().BeOfType<OptionalNone<int>>();
        }


        [Test]
        public void None_BindNone_TaskOptional()
        {
            var result = Optional<string>.None().BindNoneAsync(FuncTaskOptionalOnNone);
            result.Should().BeOfType<Task<Optional<string>>>();
            result.Result.Should().BeOfType<OptionalJust<string>>();
            (result.Result as OptionalJust<string>)._value.Should().Be("none");
        }
    }
}
