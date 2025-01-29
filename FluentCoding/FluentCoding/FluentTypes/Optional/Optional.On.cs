using System.Diagnostics.Contracts;

namespace FluentCoding
{
    public readonly partial struct Optional<O>
    {
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
