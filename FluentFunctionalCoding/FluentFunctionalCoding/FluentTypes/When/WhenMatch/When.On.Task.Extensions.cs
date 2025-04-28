namespace FluentFunctionalCoding
{
    public static partial class WhenForTasks
    {

        public static async Task<When<T>> OnTrueAsynch<T>(this Task<When<T>> when, Action<T> actionToCallOnSubject)
            => (await when).OnTrue(actionToCallOnSubject);

        public static async Task<When<T>> OnFalseAsynch<T>(this Task<When<T>> when, Action<T> actionToCallOnSubject)
            => (await when).OnFalse(actionToCallOnSubject);


        public static async Task<When<T>> OnTrueAsynch<T, X>(this Task<When<T>> when, Func<T, X> actionToCallOnSubject)
           => (await when).OnTrue(actionToCallOnSubject);

        public static async Task<When<T>> OnFalseAsynch<T, X>(this Task<When<T>> when, Func<T, X> actionToCallOnSubject)
            => (await when).OnFalse(actionToCallOnSubject);
    }
}
