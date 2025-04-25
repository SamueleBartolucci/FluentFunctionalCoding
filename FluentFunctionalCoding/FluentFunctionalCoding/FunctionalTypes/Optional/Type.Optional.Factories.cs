namespace FluentFunctionalCoding
{
    public abstract partial record Optional<O>// : Optional<O>
    {
        public static Optional<O> None() => new None<O>();

        public static Optional<O> Some(O value) => value == null ?
                                                            new None<O>() :
                                                            new Some<O>(value);
    }
}
