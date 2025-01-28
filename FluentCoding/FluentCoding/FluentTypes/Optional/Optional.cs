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


        /// <summary>
        /// Apply an action on the Subject when IsSome    
        /// Then return the Optional
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        [Pure]
        public Optional<O> OnSome(Action<O> action)
        {
            action(_subject);
            return this;
        }


        /// <summary>
        /// Apply an action on the Subject when IsSome    
        /// Then return the Optional and discard the func output
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        [Pure]
        public Optional<O> OnSome<T>(Func<O, T> funcAsAction)
        {
            funcAsAction(_subject);
            return this;
        }

        /// <summary>
        /// Apply a generic action when the subject IsNone        
        /// Then return the Optional
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        [Pure]
        public Optional<O> OnNone(Action action)
        {
            action();
            return this;
        }

        /// <summary>
        /// Apply a generic action when the subject IsNone        
        /// Then return the Optional and discard the func output
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcAsAction"></param>
        /// <returns></returns>
        [Pure]
        public Optional<O> OnNone<T>(Func<T> funcAsAction)
        {
            funcAsAction();
            return this;
        }
    }
}
