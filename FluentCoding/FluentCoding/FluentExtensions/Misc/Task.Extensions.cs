namespace FluentFunctionalCoding
{
    public static partial class MiscExtensions
    {
        public static Task<T> ToTask<T>(this T toWrapInTask) => Task.FromResult(toWrapInTask);
    }
}
