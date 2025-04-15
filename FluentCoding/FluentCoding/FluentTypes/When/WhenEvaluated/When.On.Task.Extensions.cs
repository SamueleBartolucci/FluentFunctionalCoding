namespace FluentFunctionalCoding
{
    public static partial class WhenForTasks
    {

        public static async Task<IWhen<T>> OnTrueAsynch<T>(this Task<IWhen<T>> when, Action<T> actionToCallOnSubject)
            => (await when).OnTrue(actionToCallOnSubject);

        public static async Task<IWhen<T>> OnFalseAsynch<T>(this Task<IWhen<T>> when, Action<T> actionToCallOnSubject)
            => (await when).OnFalse(actionToCallOnSubject);


        public static async Task<IWhen<T>> OnTrueAsynch<T, X>(this Task<IWhen<T>> when, Func<T, X> actionToCallOnSubject)
           => (await when).OnTrue(actionToCallOnSubject);

        public static async Task<IWhen<T>> OnFalseAsynch<T, X>(this Task<IWhen<T>> when, Func<T, X> actionToCallOnSubject)
            => (await when).OnFalse(actionToCallOnSubject);
    }
}
