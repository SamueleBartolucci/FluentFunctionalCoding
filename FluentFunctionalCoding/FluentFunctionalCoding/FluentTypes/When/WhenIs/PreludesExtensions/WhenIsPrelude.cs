namespace FluentFunctionalCoding.FluentPreludes
{
    public static partial class PreludeFluent
    {
        /// <summary>
        /// Creates a new <see cref="WhenIs{T}"/> instance for the specified subject.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <param name="whenSubject">The subject to evaluate conditions on.</param>
        /// <returns>A new <see cref="WhenIs{T}"/> instance.</returns>
        public static WhenIs<T> When<T>(this T whenSubject) => Prelude.When(whenSubject);
    }
}
