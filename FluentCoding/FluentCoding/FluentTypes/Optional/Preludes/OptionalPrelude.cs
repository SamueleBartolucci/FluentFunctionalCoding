namespace FluentCoding
{
    public static partial class Prelude
    {
        /// <summary>
        /// Return Some of the input value
        /// If the value is null the return is None
        /// </summary>
        /// <typeparam name="O"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Optional<O> Some<O>(this O value) => Optional<O>.Some(value);

        /// <summary>
        /// Return None
        /// </summary>
        /// <returns></returns>
        public static Optional<O> None<O>() => Optional<O>.None();

    }
}
