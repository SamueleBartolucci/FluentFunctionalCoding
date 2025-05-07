namespace FluentFunctionalCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Wraps the specified value in a Task, returning a completed Task with the value as its result.
        /// </summary>
        /// <typeparam name="T">The type of the value to wrap.</typeparam>
        /// <param name="toWrapInTask">The value to wrap in a Task.</param>
        /// <returns>A completed Task containing the specified value.</returns>
        public static Task<T> ToTask<T>(this T toWrapInTask) => Task.FromResult(toWrapInTask);
    }
}
