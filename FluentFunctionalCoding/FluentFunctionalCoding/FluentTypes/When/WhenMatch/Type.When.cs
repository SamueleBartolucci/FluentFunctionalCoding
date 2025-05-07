namespace FluentFunctionalCoding
{
    /// <summary>
    /// Represents a conditional wrapper for a subject of type <typeparamref name="T"/>, indicating a true or false state.
    /// </summary>
    public partial record When<T>
    {
        /// <summary>
        /// The subject value wrapped by this <see cref="When{T}"/>.
        /// </summary>
        internal readonly T _subject;
        /// <summary>
        /// Indicates whether the condition is true.
        /// </summary>
        internal readonly bool _isTrue = false;

        /// <summary>
        /// Gets a value indicating whether the condition is true.
        /// </summary>
        public bool IsTrue => _isTrue;
        /// <summary>
        /// Gets a value indicating whether the condition is false.
        /// </summary>
        public bool IsFalse => !_isTrue;

        /// <summary>
        /// Initializes a new instance of the <see cref="When{T}"/> record.
        /// </summary>
        /// <param name="switchSubject">The subject value.</param>
        /// <param name="isTrue">The condition value.</param>
        internal When(T switchSubject, bool isTrue)
        {
            this._subject = switchSubject;
            this._isTrue = isTrue;
        }

        /// <summary>
        /// Deconstructs the <see cref="When{T}"/> into its subject value.
        /// </summary>
        /// <param name="value">The subject value.</param>
        internal void Deconstruct(out T value) => (value) = (_subject);
    }
}
