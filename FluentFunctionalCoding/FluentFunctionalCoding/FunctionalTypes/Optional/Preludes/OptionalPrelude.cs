namespace FluentFunctionalCoding
{
    public static partial class Prelude
    {        
        public static Optional<O> Optional<O>(this O value) => FluentFunctionalCoding.Optional<O>.Some(value);

        public static Optional<O> OptionalNone<O>() => FluentFunctionalCoding.Optional<O>.None();

    }
}
