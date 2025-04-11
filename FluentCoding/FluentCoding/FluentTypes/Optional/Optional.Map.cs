using System.Diagnostics.Contracts;


namespace FluentCoding
{

    public abstract partial record Optional<O> : IOptional<O>
    {
        [Pure]
        public IOptional<B> Map<B>(Func<O, B> mapOnSome) =>
            this switch
            {
                None<O> => Optional<B>.None(),
                Some<O>(var v) => Optional<B>.Some(mapOnSome(v)),
                _ => throw UnknowOptionalType()
            };

        [Pure]
        public IOptional<O> MapNone(Func<O> mapOnNone) =>
            this switch
            {
                None<O> => Some(mapOnNone()),
                Some<O>(var v) => Some(v),
                _ => throw UnknowOptionalType()
            };
    }

}
