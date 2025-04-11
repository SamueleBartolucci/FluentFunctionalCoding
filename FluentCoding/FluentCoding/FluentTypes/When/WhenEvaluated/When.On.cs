namespace FluentCoding
{
    public partial record When<T> : IWhen<T>
    {
        public IWhen<T> OnTrue(Action<T> funcAsActionToCallOnSubject)
        {
            if (_isTrue)
                funcAsActionToCallOnSubject(_subject);

            return this;
        }

        public IWhen<T> OnFalse(Action<T> funcAsActionToCallOnSubject)
        {
            if (!_isTrue)
                funcAsActionToCallOnSubject(_subject);

            return this;
        }

        public IWhen<T> OnTrue<X>(Func<T, X> funcAsActionToCallOnSubject)
        {
            if (_isTrue)
                funcAsActionToCallOnSubject(_subject);

            return this;
        }

        public IWhen<T> OnFalse<X>(Func<T, X> funcAsActionToCallOnSubject)
        {
            if (!_isTrue)
                funcAsActionToCallOnSubject(_subject);

            return this;
        }
    }
}
