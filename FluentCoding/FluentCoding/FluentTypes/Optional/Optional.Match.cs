using System.Diagnostics.Contracts;

namespace FluentCoding
{

    public abstract partial record Optional<O>
    {
        [Pure]
        public O MatchNone(Func<O> mapOnNone) 
            => this switch
            {
                Nothing<O> => mapOnNone(),
                Just<O>(var v) => v,
                _ => throw UnknowImplementation()
            }; 

        [Pure]
        public O MatchNone(O valueWhenNone) 
            => this switch
            {
                Nothing<O> => valueWhenNone,
                Just<O>(var v) => v,
                _ => throw UnknowImplementation()
            }; 

        [Pure]
        public T Match<T>(Func<O, T> mapOnSome, Func<T> mapOnNone)
             => this switch
             {
                 Nothing<O> => mapOnNone(),
                 Just<O>(var v) => mapOnSome(v),
                 _ => throw UnknowImplementation()
             }; 
    }

}
