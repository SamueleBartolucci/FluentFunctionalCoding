using System.Diagnostics.Contracts;

namespace FluentCoding
{

    public readonly partial struct Optional<O>
    {
        [Pure]
        public Optional<B> Map<B>(Func<O, B> mapOnSome)
            => _isSomething ? Optional<B>.Some(mapOnSome(_subject)) : Optional<B>.None();

        [Pure]
        public Optional<O> MapNone(Func<O> mapOnNone)
            => _isSomething ? Some(_subject) : Some(mapOnNone());
    }

}
