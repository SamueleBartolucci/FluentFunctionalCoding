namespace FluentFunctionalCoding.FluentExtensions.While
{
    public static partial class FluentExtension
    {
        public static T While<T>(Func<T> initializeWhileValue, Func<T, bool> valueIsTrueWhen, Func<T, T> funcOnValueWhileTrue)
        {
            var whileValue = initializeWhileValue();
            while (valueIsTrueWhen(whileValue))
                whileValue = funcOnValueWhileTrue(whileValue);
            return whileValue;
        }
    }
}
