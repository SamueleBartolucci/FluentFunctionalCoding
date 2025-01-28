using System.Diagnostics.Contracts;

namespace FluentCoding
{

    public readonly partial struct Optional<O>
    {
        [Pure]
        public O MatchNone(Func<O> mapOnNone)
            => _isSomething ? _subject : mapOnNone();

        [Pure]
        public O MatchNone(O valueWhenNone)
            => _isSomething ? _subject : valueWhenNone;

        [Pure]
        public T Match<T>(Func<O, T> mapOnSome, Func<T> mapOnNone)
            => _isSomething ? mapOnSome(_subject) : mapOnNone();
    }

}
