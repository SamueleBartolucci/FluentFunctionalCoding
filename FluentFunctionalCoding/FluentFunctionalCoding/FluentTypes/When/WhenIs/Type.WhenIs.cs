namespace FluentFunctionalCoding
{
    public partial record WhenIs<T>
    {
        internal readonly T _whenSubject;
                
        internal WhenIs(T subject) => this._whenSubject = subject;

        internal void Deconstruct(out T value) => (value) = (_whenSubject);
    }
}
