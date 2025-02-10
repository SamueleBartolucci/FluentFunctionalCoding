using System.Diagnostics.Contracts;

namespace FluentCoding
{

    public abstract partial record Optional<O>
    {
        [Pure]
        public O MatchNone(Func<O> mapOnNone) 
            => this switch
            {
                OptionalNone<O> => mapOnNone(),
                OptionalJust<O>(var v) => v,
                _ => throw UnknowOptionalType()
            }; 

        [Pure]
        public O MatchNone(O valueWhenNone) 
            => this switch
            {
                OptionalNone<O> => valueWhenNone,
                OptionalJust<O>(var v) => v,
                _ => throw UnknowOptionalType()
            }; 

        [Pure]
        public T Match<T>(Func<O, T> mapOnSome, Func<T> mapOnNone)
             => this switch
             {
                 OptionalNone<O> => mapOnNone(),
                 OptionalJust<O>(var v) => mapOnSome(v),
                 _ => throw UnknowOptionalType()
             };


        [Pure]
        public T Match<T>(Func<O, T> mapOnSome, T valueOnNone)
             => this switch
             {
                 OptionalNone<O> => valueOnNone,
                 OptionalJust<O>(var v) => mapOnSome(v),
                 _ => throw UnknowOptionalType()
             };
    }

}
