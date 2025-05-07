namespace FluentFunctionalCoding.FluentPreludes
{
    /// <summary>
    /// Provides extension methods for creating SwitchMap instances in a fluent style.
    /// </summary>
    public static partial class PreludeFluent
    {
        /// <summary>
        /// Creates a SwitchMapBase for the given subject.
        /// </summary>
        public static SwitchMapBase<T, T1> Switch<T, T1>(this T subject) => Prelude.Switch<T, T1>(subject);

        /// <summary>
        /// Creates a SwitchMap with a default case function.
        /// </summary>
        public static SwitchMap<T, T1> Switch<T, T1>(this T subject, Func<T, T1> defaultCase) => Prelude.Switch(subject, defaultCase);

        /// <summary>
        /// Creates a SwitchMap with a default result value.
        /// </summary>
        public static SwitchMap<T, T1> Switch<T, T1>(this T subject, T1 defaultResult) => Prelude.Switch(subject, defaultResult);
    }

}
