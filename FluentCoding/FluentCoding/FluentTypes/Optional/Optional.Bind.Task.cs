using System.Diagnostics.Contracts;

namespace FluentCoding
{
    public abstract partial record Optional<O> : IOptional<O>
    {

        [Pure]
        public async Task<IOptional<T>> BindAsync<T>(Func<O, Task<IOptional<T>>> bindAsyncOnSome)
             => this switch
             {
                 None<O> => Optional<T>.None(),
                 Some<O>(var v) => await bindAsyncOnSome(v),
                 _ => throw UnknowOptionalType()
             };

        [Pure]
        public async Task<IOptional<O>> BindNoneAsync(Func<Task<IOptional<O>>> bindAsyncOnNone)
            => this switch
            {
                None<O> => await bindAsyncOnNone(),
                Some<O>(var v) => Some(v),
                _ => throw UnknowOptionalType()
            };
    }
}
