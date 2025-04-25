using System.Runtime.CompilerServices;

namespace FluentFunctionalCoding
{
    public static partial class MiscExtensions
    {   
        public static Func<Nothing> AsFunc(this Action actionToFunc) => () => { actionToFunc(); return Nothing.SoftNull; };
        public static Func<T, Nothing> AsFunc<T>(this Action<T> actionToFunc) => s => actionToFunc.Apply(s).AsFunc().Invoke();
        public static Func<T1, T2, Nothing> AsFunc<T1,T2>(this Action<T1, T2> actionToFunc) => (t1, t2) => actionToFunc.Apply(t1).Apply(t2).AsFunc().Invoke();
        public static Func<T1, T2, T3, Nothing> AsFunc<T1, T2, T3>(this Action<T1, T2, T3> actionToFunc) => (t1, t2, t3) => actionToFunc.Apply(t1).Apply(t2).Apply(t3).AsFunc().Invoke();


    }
}

