using System.Diagnostics.Contracts;

namespace FluentCoding
{
    public abstract partial record Optional<O>
    {
        [Pure]
        public Optional<T> Bind<T>(Func<O, Optional<T>> bindOnSome)
            => this switch
            {
                None<O> => Optional<T>.None(),
                Some<O>(var v) => bindOnSome(v),
                _ => throw UnknowOptionalType()
            };

        [Pure]
        public Optional<O> BindNone(Func<Optional<O>> bindOnNone)
             => this switch
             {
                 None<O> => bindOnNone(),
                 Some<O>(var v) => Some(v),
                 _ => throw UnknowOptionalType()
             };
    }
}
