namespace FluentFunctionalCoding
{
    public static partial class Prelude
    {
        /// <summary>
        /// Creates a new instance of <see cref="SwitchMapBase{TIn, TOut}"/> with the specified switch subject.
        /// </summary>
        /// <typeparam name="TIn">The type of the input.</typeparam>
        /// <typeparam name="TOut">The type of the output.</typeparam>
        /// <param name="switchSubject">The subject to switch on.</param>
        /// <returns>A new instance of <see cref="SwitchMapBase{TIn, TOut}"/>.</returns>
        public static SwitchMapBase<TIn, TOut> Switch<TIn, TOut>(TIn switchSubject) => new SwitchMapBase<TIn, TOut>(switchSubject);

        /// <summary>
        /// Creates a new instance of <see cref="SwitchMap{TIn, TOut}"/> with the specified switch subject and default case.
        /// </summary>
        /// <typeparam name="TIn">The type of the input.</typeparam>
        /// <typeparam name="TOut">The type of the output.</typeparam>
        /// <param name="switchSubject">The subject to switch on.</param>
        /// <param name="defaultCase">The default case value.</param>
        /// <returns>A new instance of <see cref="SwitchMap{TIn, TOut}"/>.</returns>
        public static SwitchMap<TIn, TOut> Switch<TIn, TOut>(TIn switchSubject, TOut defaultCase) => new DefaultCase<TIn, TOut>(switchSubject, _ => defaultCase);

        /// <summary>
        /// Creates a new instance of <see cref="SwitchMap{TIn, TOut}"/> with the specified switch subject and default case function.
        /// </summary>
        /// <typeparam name="TIn">The type of the input.</typeparam>
        /// <typeparam name="TOut">The type of the output.</typeparam>
        /// <param name="switchSubject">The subject to switch on.</param>
        /// <param name="defaultCase">A function to determine the default case value.</param>
        /// <returns>A new instance of <see cref="SwitchMap{TIn, TOut}"/>.</returns>
        public static SwitchMap<TIn, TOut> Switch<TIn, TOut>(TIn switchSubject, Func<TIn, TOut> defaultCase) => new DefaultCase<TIn, TOut>(switchSubject, defaultCase);

        /// <summary>
        /// Asynchronously creates a new instance of <see cref="SwitchMap{T, T1}"/> with the specified task and default case function.
        /// </summary>
        /// <typeparam name="T">The type of the input.</typeparam>
        /// <typeparam name="T1">The type of the output.</typeparam>
        /// <param name="subject">The task representing the subject to switch on.</param>
        /// <param name="defaultCase">A function to determine the default case value.</param>
        /// <returns>A task that represents the asynchronous operation, containing a new instance of <see cref="SwitchMap{T, T1}"/>.</returns>
        public static async Task<SwitchMap<T, T1>> Switch<T, T1>(Task<T> subject, Func<T, T1> defaultCase)
        {
            await (subject);
            return Prelude.Switch(subject.Result, defaultCase);
        }

        /// <summary>
        /// Asynchronously creates a new instance of <see cref="SwitchMap{T, T1}"/> with the specified task and default case value.
        /// </summary>
        /// <typeparam name="T">The type of the input.</typeparam>
        /// <typeparam name="T1">The type of the output.</typeparam>
        /// <param name="subject">The task representing the subject to switch on.</param>
        /// <param name="defaultCase">The default case value.</param>
        /// <returns>A task that represents the asynchronous operation, containing a new instance of <see cref="SwitchMap{T, T1}"/>.</returns>
        public static async Task<SwitchMap<T, T1>> Switch<T, T1>(Task<T> subject, T1 defaultCase)
        {
            await (subject);
            return Prelude.Switch(subject.Result, defaultCase);
        }
    }
}


