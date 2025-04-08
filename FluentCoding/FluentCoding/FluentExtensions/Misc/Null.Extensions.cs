namespace FluentCoding
{
    public static partial class MiscExtensions
    {
        public static bool IsNull<T>(this T valueToNullCheck) => valueToNullCheck == null;
        public static bool IsNullOrEmpty(this string valueToNullCheck) => string.IsNullOrEmpty(valueToNullCheck);
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> valueToNullCheck) => valueToNullCheck == null || !valueToNullCheck.Any();
    }
}
