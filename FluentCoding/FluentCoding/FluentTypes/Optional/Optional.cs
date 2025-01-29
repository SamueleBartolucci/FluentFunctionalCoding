using System.Diagnostics.Contracts;

namespace FluentCoding
{
    public readonly partial struct Optional<O>
    {
        internal readonly O _subject = default;
        internal readonly bool _isSomething = false;


        internal Optional(O optionalValue, bool isSome)
        {
            this._subject = optionalValue;
            this._isSomething = isSome;
        }

        public static Optional<O> None() => new(default, false);

        public static Optional<O> Some(O value) => new(value, true);

        /// <summary>
        /// Check if Optional value is some
        /// </summary>
        /// <returns></returns>
        public bool IsSome => this._isSomething;


        /// <summary>
        /// Check if Optional value is None
        /// </summary>
        /// <returns></returns>
        public bool IsNone => !this._isSomething;
    }
}
