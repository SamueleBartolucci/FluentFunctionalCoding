using FluentAssertions;
using FluentFunctionalCoding;
using FluentFunctionalCoding.FluentPreludes;
using NUnit.Framework;

namespace FluentCodingTest.Outcome.Map
{
    internal class OutcomeIDisposableMap
    {
        private class DisposableTest : System.IDisposable
        {
            public bool Disposed { get; private set; }
            public string Value { get; }
            public DisposableTest(string value) { Value = value; }
            public void Dispose() { Disposed = true; }
        }

        [Test]
        public void Success_MapUsing_DisposesAndMaps()
        {
            var disposable = new DisposableTest("abc");
            var outcome = new Right<Exception, DisposableTest>(disposable);
            var mapped = outcome.MapUsing(d => d.Value.Length);
            mapped.Should().BeOfType<Right<Exception, int>>();
            ((Right<Exception, int>?)mapped)?._successValue.Should().Be(3);
            disposable.Disposed.Should().BeTrue();
        }

        [Test]
        public void Failure_MapUsing_DoesNotCallMapOrDispose()
        {
            var outcome = new Left<Exception, DisposableTest>(new Exception("fail"));
            var mapped = outcome.MapUsing(d => d.Value.Length);
            mapped.Should().BeOfType<Left<Exception, int>>();
        }
    }
}
