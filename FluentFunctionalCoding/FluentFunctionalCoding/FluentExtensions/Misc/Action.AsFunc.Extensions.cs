using System.Runtime.CompilerServices;

namespace FluentFunctionalCoding
{
    public static partial class MiscExtensions
    {   
        /// <summary>
        /// Converts an Action to a Func that returns Nothing.
        /// </summary>
        /// <param name="actionToFunc">The Action to convert.</param>
        /// <returns>A Func that executes the Action and returns Nothing.SoftNull.</returns>
        public static Func<Nothing> AsFunc(this Action actionToFunc) => () => { actionToFunc(); return Nothing.SoftNull; };

        /// <summary>
        /// Converts an Action with one parameter to a Func that returns Nothing.
        /// </summary>
        /// <typeparam name="T">The type of the parameter.</typeparam>
        /// <param name="actionToFunc">The Action to convert.</param>
        /// <returns>A Func that executes the Action and returns Nothing.SoftNull.</returns>
        public static Func<T, Nothing> AsFunc<T>(this Action<T> actionToFunc) => s => actionToFunc.Apply(s).AsFunc().Invoke();

        /// <summary>
        /// Converts an Action with two parameters to a Func that returns Nothing.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <param name="actionToFunc">The Action to convert.</param>
        /// <returns>A Func that executes the Action and returns Nothing.SoftNull.</returns>
        public static Func<T1, T2, Nothing> AsFunc<T1,T2>(this Action<T1, T2> actionToFunc) => (t1, t2) => actionToFunc.Apply(t1).Apply(t2).AsFunc().Invoke();

        /// <summary>
        /// Converts an Action with three parameters to a Func that returns Nothing.
        /// </summary>
        /// <typeparam name="T1">The type of the first parameter.</typeparam>
        /// <typeparam name="T2">The type of the second parameter.</typeparam>
        /// <typeparam name="T3">The type of the third parameter.</typeparam>
        /// <param name="actionToFunc">The Action to convert.</param>
        /// <returns>A Func that executes the Action and returns Nothing.SoftNull.</returns>
        public static Func<T1, T2, T3, Nothing> AsFunc<T1, T2, T3>(this Action<T1, T2, T3> actionToFunc) => (t1, t2, t3) => actionToFunc.Apply(t1).Apply(t2).Apply(t3).AsFunc().Invoke();


    }
}

