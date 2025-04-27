namespace FluentFunctionalCoding
{
    public partial record When<T>
    {
        public When<T> OnTrue(Action<T> funcAsActionToCallOnSubject)
        {
            if (_isTrue)
                funcAsActionToCallOnSubject(_subject);

            return this;
        }

        public When<T> OnFalse(Action<T> funcAsActionToCallOnSubject)
        {
            if (!_isTrue)
                funcAsActionToCallOnSubject(_subject);

            return this;
        }

        public When<T> OnTrue<X>(Func<T, X> funcAsActionToCallOnSubject)
        {
            if (_isTrue)
                funcAsActionToCallOnSubject(_subject);

            return this;
        }

        public When<T> OnFalse<X>(Func<T, X> funcAsActionToCallOnSubject)
        {
            if (!_isTrue)
                funcAsActionToCallOnSubject(_subject);

            return this;
        }
    }
}
