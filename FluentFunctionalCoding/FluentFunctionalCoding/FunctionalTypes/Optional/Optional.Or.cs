using FluentFunctionalCoding.FluentPreludes;

namespace FluentFunctionalCoding
{
    /// <summary>
    /// Represents an optional value and provides methods to select between two optionals or values based on various conditions.
    /// </summary>
    public abstract partial record Optional<O>// : Optional<O>
    {
        /// <summary>
        /// Returns the right Optional if the current Optional is None, or if <paramref name="chooseRight"/> is true; otherwise returns the current Optional.
        /// </summary>
        /// <param name="orRightValue">The alternative Optional to use.</param>
        /// <param name="chooseRight">If true, always choose the right Optional when current is Some.</param>
        /// <returns>An Optional value.</returns>
        public Optional<O> Or(Optional<O> orRightValue, bool chooseRight = false)
               => this switch
               {
                   None<O> => orRightValue,
                   Some<O> => chooseRight ? orRightValue : this,
                   _ => throw UnknowOptionalType()
               };

        /// <summary>
        /// Returns the right Optional if the current Optional is None, or if <paramref name="chooseRightWhen"/> returns true; otherwise returns the current Optional.
        /// </summary>
        /// <param name="orRightValue">The alternative Optional to use.</param>
        /// <param name="chooseRightWhen">A function to determine if the right Optional should be chosen when current is Some.</param>
        /// <returns>An Optional value.</returns>
        public Optional<O> Or(Optional<O> orRightValue, Func<bool> chooseRightWhen)
            => this switch
            {
                None<O> => orRightValue,
                Some<O> => chooseRightWhen() ? orRightValue : this,
                _ => throw UnknowOptionalType()
            };

        /// <summary>
        /// Returns the right Optional if the current Optional is None, or if <paramref name="chooseRightWhen"/> returns true for the contained value; otherwise returns the current Optional.
        /// </summary>
        /// <param name="orRightValue">The alternative Optional to use.</param>
        /// <param name="chooseRightWhen">A function that takes the contained value and determines if the right Optional should be chosen.</param>
        /// <returns>An Optional value.</returns>
        public Optional<O> Or(Optional<O> orRightValue, Func<O, bool> chooseRightWhen)
          => this switch
          {
              None<O> => orRightValue,
              Some<O>(var v) => chooseRightWhen(v) ? orRightValue : this,
              _ => throw UnknowOptionalType()
          };

        /// <summary>
        /// Returns an Optional created from <paramref name="orRightValueFunc"/> if the current Optional is None, or if <paramref name="chooseRight"/> is true; otherwise returns the current Optional.
        /// </summary>
        /// <param name="orRightValueFunc">A function to generate the alternative value.</param>
        /// <param name="chooseRight">If true, always choose the right value when current is Some.</param>
        /// <returns>An Optional value.</returns>
        public Optional<O> Or(Func<O> orRightValueFunc, bool chooseRight = false)
              => this switch
              {
                  None<O> => Optional<O>.Some(orRightValueFunc()),
                  Some<O> s => chooseRight ? Optional<O>.Some(orRightValueFunc()) : s,
                  _ => throw UnknowOptionalType()
              };

        /// <summary>
        /// Returns an Optional created from <paramref name="orRightValueFunc"/> if the current Optional is None, or if <paramref name="chooseRightWhen"/> returns true; otherwise returns the current Optional.
        /// </summary>
        /// <param name="orRightValueFunc">A function to generate the alternative value.</param>
        /// <param name="chooseRightWhen">A function to determine if the right value should be chosen when current is Some.</param>
        /// <returns>An Optional value.</returns>
        public Optional<O> Or(Func<O> orRightValueFunc, Func<bool> chooseRightWhen)
            => this switch
            {
                None<O> => Optional<O>.Some(orRightValueFunc()),
                Some<O> s => chooseRightWhen() ? Optional<O>.Some(orRightValueFunc()) : s,
                _ => throw UnknowOptionalType()
            };

        /// <summary>
        /// Returns an Optional created from <paramref name="orRightValueFunc"/> if the current Optional is None, or if <paramref name="chooseRightWhen"/> returns true for the contained value; otherwise returns the current Optional.
        /// </summary>
        /// <param name="orRightValueFunc">A function to generate the alternative value.</param>
        /// <param name="chooseRightWhen">A function that takes the contained value and determines if the right value should be chosen.</param>
        /// <returns>An Optional value.</returns>
        public Optional<O> Or(Func<O> orRightValueFunc, Func<O, bool> chooseRightWhen)
           => this switch
           {
               None<O> => Optional<O>.Some(orRightValueFunc()),
               Some<O>(var v) => chooseRightWhen(v) ? orRightValueFunc().ToOptional() : this,
               _ => throw UnknowOptionalType()
           };

    }
}
