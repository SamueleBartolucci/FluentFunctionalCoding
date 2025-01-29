using System;
using System.Diagnostics.Contracts;

namespace FluentCoding
{
    public readonly partial struct Optional<O>
    {
        [Pure]
        public Optional<T> Bind<T>(Func<O, Optional<T>> bindOnSome)
            => _isSomething ? bindOnSome(_subject) : Optional<T>.None();

        [Pure]
        public Optional<O> BindNone(Func<Optional<O>> bindOnNone)
            => _isSomething ? Some(_subject) : bindOnNone();

        [Pure]
        public async Task<Optional<T>> BindAsync<T>(Func<O, Task<Optional<T>>> bindAsyncOnSome)
            => _isSomething ? await bindAsyncOnSome(_subject) : Optional<T>.None();

        [Pure]
        public async Task<Optional<O>> BindNoneAsync(Func<Task<Optional<O>>> bindAsyncOnNone)
            => _isSomething ? Some(_subject) : await bindAsyncOnNone();
    }
}
