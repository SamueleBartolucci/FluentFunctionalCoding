namespace FluentFunctionalCoding.FluentPreludes
{
    public static partial class PreludeFluent
    {
        /// <summary>
        /// Wrap the input value in the Optional Context (Some if not null, None otherwise)
        /// </summary>
        /// <typeparam name="O"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Optional<O> ToOptional<O>(this O value) => Prelude.Optional(value);

        /// <summary>
        /// Returns a None Optional.
        /// </summary>
        /// <typeparam name="O"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Optional<O> ToOptionalNone<O>(this O value) => Prelude.OptionalNone<O>();

    }
}
