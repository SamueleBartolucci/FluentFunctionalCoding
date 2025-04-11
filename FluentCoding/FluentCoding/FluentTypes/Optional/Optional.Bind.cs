using System.Diagnostics.Contracts;

namespace FluentCoding
{
    public abstract partial record Optional<O> : IOptional<O>
    {
        [Pure]
        public IOptional<T> Bind<T>(Func<O, IOptional<T>> bindOnSome)
            => this switch
            {
                None<O> => Optional<T>.None(),
                Some<O>(var v) => bindOnSome(v),
                _ => throw UnknowOptionalType()
            };

        [Pure]
        public IOptional<O> BindNone(Func<IOptional<O>> bindOnNone)
             => this switch
             {
                 None<O> => bindOnNone(),
                 Some<O>(var v) => Some(v),
                 _ => throw UnknowOptionalType()
             };
    }
}
