using System.Diagnostics.Contracts;


namespace FluentCoding
{

    public abstract partial record Optional<O>
    {
        [Pure]
        public Optional<B> Map<B>(Func<O, B> mapOnSome) =>
            this switch
            {
                Nothing<O> => Optional<B>.None(),
                Just<O>(var v) => Optional<B>.Some(mapOnSome(v)),
                _ => throw UnknowImplementation()
            };

        [Pure]
        public Optional<O> MapNone(Func<O> mapOnNone) =>
            this switch
            {
                Nothing<O> => Some(mapOnNone()),
                Just<O>(var v) => Some(v),
                _ => throw UnknowImplementation()
            };
}

}
