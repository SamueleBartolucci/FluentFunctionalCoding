namespace FluentFunctionalCoding
{

    public static partial class OutcomeExtensions
    {
        /// <summary>
        /// Maps the success value using the provided function, disposing the value after mapping if it implements IDisposable.
        /// </summary>
        /// <typeparam name="L">The value when outcome is Left</typeparam>
        /// <typeparam name="R">The value when outcome is Right </typeparam>
        /// <typeparam name="TResult">The result type</typeparam>
        /// <param name="outcome"></param>
        /// <param name="mapSuccess">The mapping function to apply to the success value</param>
        /// <returns>An Outcome with the mapped success value, or the original failure.</returns>
        public static Outcome<L, TResult> MapUsing<L, R,TResult>(this Outcome<L,R> outcome, Func<R, TResult> mapSuccess) where R:IDisposable =>        
            outcome switch
            {
                Right<L, R> (var rightValue)=> new Right<L, TResult>(rightValue.MapUsing(mapSuccess)),
                Left<L, R>(var leftValue) => new Left<L, TResult>(leftValue),
                _ => throw Outcome<L, TResult>.UnknownOutcomeType()
            };      
    }
}