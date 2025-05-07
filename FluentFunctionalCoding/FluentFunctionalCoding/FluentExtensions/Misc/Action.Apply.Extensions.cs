using System.Runtime.CompilerServices;

namespace FluentFunctionalCoding
{
    public static partial class FluentExtension
    {        
        /// <summary>
        /// Applies the specified argument to an Action with one parameter, returning a parameterless Action.
        /// </summary>
        /// <typeparam name="T1">The type of the argument.</typeparam>
        /// <param name="action">The Action to partially apply.</param>
        /// <param name="t1">The argument to apply.</param>
        /// <returns>A parameterless Action with the argument applied.</returns>
        public static Action Apply<T1>(this Action<T1> action, T1 t1) => () => action(t1);

        /// <summary>
        /// Applies the first argument to an Action with two parameters, returning an Action with one parameter.
        /// </summary>
        /// <typeparam name="T1">The type of the first argument.</typeparam>
        /// <typeparam name="T2">The type of the second argument.</typeparam>
        /// <param name="action">The Action to partially apply.</param>
        /// <param name="t1">The first argument to apply.</param>
        /// <returns>An Action with one parameter with the first argument applied.</returns>
        public static Action<T2> Apply<T1, T2>(this Action<T1, T2> action, T1 t1) => (t2) => action(t1, t2);

        /// <summary>
        /// Applies the first argument to an Action with three parameters, returning an Action with two parameters.
        /// </summary>
        /// <typeparam name="T1">The type of the first argument.</typeparam>
        /// <typeparam name="T2">The type of the second argument.</typeparam>
        /// <typeparam name="T3">The type of the third argument.</typeparam>
        /// <param name="action">The Action to partially apply.</param>
        /// <param name="t1">The first argument to apply.</param>
        /// <returns>An Action with two parameters with the first argument applied.</returns>
        public static Action<T2, T3> Apply<T1, T2, T3>(this Action<T1, T2, T3> action, T1 t1) => (t2, t3) => action(t1, t2, t3);

    }
}

