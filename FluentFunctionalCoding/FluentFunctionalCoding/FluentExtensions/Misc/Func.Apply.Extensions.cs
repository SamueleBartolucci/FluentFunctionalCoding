using System.Runtime.CompilerServices;

namespace FluentFunctionalCoding
{
    public static partial class MiscExtensions
    {   
        public static Func<TOut> Apply<T1, TOut>(this Func<T1, TOut> func, T1 t1) => () => func(t1);
        public static Func<T2, TOut> Apply<T1, T2, TOut>(this Func<T1, T2, TOut> func, T1 t1) => (t2) => func(t1, t2);
        public static Func<T2, T3, TOut> Apply<T1, T2, T3, TOut>(this Func<T1, T2, T3, TOut> func, T1 t1) => (t2, t3) => func(t1, t2, t3);       
    }
}

