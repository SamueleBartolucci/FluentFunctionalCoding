namespace FluentFunctionalCoding.FluentPreludes
{
    /// <summary>
    /// Provides extension methods for creating SwitchMap instances asynchronously.
    /// </summary>
    public static partial class PreludeFluent
    {
        /// <summary>
        /// Asynchronously creates a SwitchMap with a default case function.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <typeparam name="T1">The type of the result.</typeparam>
        /// <param name="subject">The asynchronous subject.</param>
        /// <param name="defaultCase">The default case function.</param>
        /// <returns>A Task representing the asynchronous operation, with a SwitchMap result.</returns>
        public static Task<SwitchMap<T, T1>> SwitchAsync<T, T1>(this Task<T> subject, Func<T, T1> defaultCase)
         => Prelude.Switch(subject, defaultCase);

        /// <summary>
        /// Asynchronously creates a SwitchMap with a default result value.
        /// </summary>
        /// <typeparam name="T">The type of the subject.</typeparam>
        /// <typeparam name="T1">The type of the result.</typeparam>
        /// <param name="subject">The asynchronous subject.</param>
        /// <param name="defaultCase">The default result value.</param>
        /// <returns>A Task representing the asynchronous operation, with a SwitchMap result.</returns>
        public static Task<SwitchMap<T, T1>> SwitchAsync<T, T1>(this Task<T> subject, T1 defaultCase)
            => Prelude.Switch(subject, defaultCase);
    }

}
