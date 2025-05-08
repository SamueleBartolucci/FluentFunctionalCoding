namespace FluentFunctionalCoding
{
    public partial record WhenIs<T>
    {
        /// <summary>
        /// Gets the subject value wrapped by this <see cref="WhenIs{T}"/> instance.
        /// </summary>
        internal readonly T _whenSubject;
                
        /// <summary>
        /// Initializes a new instance of the <see cref="WhenIs{T}"/> record with the specified subject.
        /// </summary>
        /// <param name="subject">The subject value to wrap for conditional checks.</param>
        internal WhenIs(T subject) => this._whenSubject = subject;

        /// <summary>
        /// Deconstructs the <see cref="WhenIs{T}"/> into its subject value.
        /// </summary>
        /// <param name="value">The subject value.</param>
        internal void Deconstruct(out T value) => (value) = (_whenSubject);
    }
}
