using System.Runtime.CompilerServices;

namespace FluentFunctionalCoding
{
    public static partial class MiscExtensions
    {        
        public static Action Apply<T1>(this Action<T1> action, T1 t1) => () => action(t1);
        public static Action<T2> Apply<T1, T2>(this Action<T1, T2> action, T1 t1) => (t2) => action(t1, t2);
        public static Action<T2, T3> Apply<T1, T2, T3>(this Action<T1, T2, T3> action, T1 t1) => (t2, t3) => action(t1, t2, t3);

    }
}

