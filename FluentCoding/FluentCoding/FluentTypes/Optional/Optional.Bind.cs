using System;
using System.Diagnostics.Contracts;

namespace FluentCoding
{
    public abstract partial record Optional<O>
    {
        [Pure]
        public Optional<T> Bind<T>(Func<O, Optional<T>> bindOnSome)
            => this switch
            {
                Nothing<O> => Optional<T>.None(),
                Just<O> (var v) => bindOnSome(v),
                _ => throw UnknowImplementation()
            };

        [Pure]
        public Optional<O> BindNone(Func<Optional<O>> bindOnNone)
             => this switch
             {
                 Nothing<O> => bindOnNone(),
                 Just<O>(var v) => Some(v),
                 _ => throw UnknowImplementation()
             };

        [Pure]
        public async Task<Optional<T>> BindAsync<T>(Func<O, Task<Optional<T>>> bindAsyncOnSome)
             => this switch
             {
                 Nothing<O> => Optional<T>.None(),
                 Just<O>(var v) => await bindAsyncOnSome(v),
                 _ => throw UnknowImplementation()
             };

        [Pure]
        public async Task<Optional<O>> BindNoneAsync(Func<Task<Optional<O>>> bindAsyncOnNone)
            => this switch
            {
                Nothing<O> => await bindAsyncOnNone(),
                Just<O>(var v) => Some(v),
                _ => throw UnknowImplementation()
            };
    }
}
