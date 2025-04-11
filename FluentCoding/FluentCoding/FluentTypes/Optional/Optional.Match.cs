using System.Diagnostics.Contracts;

namespace FluentCoding
{

    public abstract partial record Optional<O> : IOptional<O>
    {
        [Pure]
        public O MatchNone(Func<O> mapOnNone)
            => this switch
            {
                None<O> => mapOnNone(),
                Some<O>(var v) => v,
                _ => throw UnknowOptionalType()
            };

        [Pure]
        public O MatchNone(O valueWhenNone)
            => this switch
            {
                None<O> => valueWhenNone,
                Some<O>(var v) => v,
                _ => throw UnknowOptionalType()
            };

        [Pure]
        public T Match<T>(Func<O, T> mapOnSome, Func<T> mapOnNone)
             => this switch
             {
                 None<O> => mapOnNone(),
                 Some<O>(var v) => mapOnSome(v),
                 _ => throw UnknowOptionalType()
             };


        [Pure]
        public T Match<T>(Func<O, T> mapOnSome, T valueOnNone)
             => this switch
             {
                 None<O> => valueOnNone,
                 Some<O>(var v) => mapOnSome(v),
                 _ => throw UnknowOptionalType()
             };
    }

}
