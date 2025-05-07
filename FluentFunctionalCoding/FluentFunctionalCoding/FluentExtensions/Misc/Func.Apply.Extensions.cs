using System.Runtime.CompilerServices;

namespace FluentFunctionalCoding
{
    public static partial class FluentExtension
    {   
        /// <summary>
        /// Partially applies the first argument to a function with one parameter, returning a parameterless function.
        /// </summary>
        /// <typeparam name="T1">The type of the first argument.</typeparam>
        /// <typeparam name="TOut">The return type of the function.</typeparam>
        /// <param name="func">The function to partially apply.</param>
        /// <param name="t1">The argument to apply.</param>
        /// <returns>A parameterless function with the argument applied.</returns>
        public static Func<TOut> Apply<T1, TOut>(this Func<T1, TOut> func, T1 t1) => () => func(t1);

        /// <summary>
        /// Partially applies the first argument to a function with two parameters, returning a function with one parameter.
        /// </summary>
        /// <typeparam name="T1">The type of the first argument.</typeparam>
        /// <typeparam name="T2">The type of the second argument.</typeparam>
        /// <typeparam name="TOut">The return type of the function.</typeparam>
        /// <param name="func">The function to partially apply.</param>
        /// <param name="t1">The argument to apply.</param>
        /// <returns>A function with one parameter with the first argument applied.</returns>
        public static Func<T2, TOut> Apply<T1, T2, TOut>(this Func<T1, T2, TOut> func, T1 t1) => (t2) => func(t1, t2);

        /// <summary>
        /// Partially applies the first argument to a function with three parameters, returning a function with two parameters.
        /// </summary>
        /// <typeparam name="T1">The type of the first argument.</typeparam>
        /// <typeparam name="T2">The type of the second argument.</typeparam>
        /// <typeparam name="T3">The type of the third argument.</typeparam>
        /// <typeparam name="TOut">The return type of the function.</typeparam>
        /// <param name="func">The function to partially apply.</param>
        /// <param name="t1">The argument to apply.</param>
        /// <returns>A function with two parameters with the first argument applied.</returns>
        public static Func<T2, T3, TOut> Apply<T1, T2, T3, TOut>(this Func<T1, T2, T3, TOut> func, T1 t1) => (t2, t3) => func(t1, t2, t3);       
    }
}

