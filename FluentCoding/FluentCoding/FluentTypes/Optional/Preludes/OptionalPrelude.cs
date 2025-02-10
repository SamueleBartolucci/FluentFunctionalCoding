namespace FluentCoding
{
    public static partial class Prelude
    {
        /// <summary>
        /// Wrap the input value in the Optional Context (Just if not null, None otherwise)
        /// </summary>
        /// <typeparam name="O"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Optional<O> ToOptional<O>(this O value) => Optional<O>.Some(value);     

    }
}
