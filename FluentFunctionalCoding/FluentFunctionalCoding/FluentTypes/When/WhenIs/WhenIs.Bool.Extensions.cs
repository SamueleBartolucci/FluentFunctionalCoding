using FluentFunctionalCoding;

namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides extension methods for <see cref="WhenIs{bool}"/> to perform conditional checks on boolean values.
    /// </summary>
    public static partial class WhenIsExtension
    {
        /// <summary>
        /// Determines whether the subject boolean value is true.
        /// </summary>
        /// <param name="whenIs">The <see cref="WhenIs{bool}"/> instance.</param>
        /// <returns>A <see cref="When{bool}"/> indicating if the value is true.</returns>
        public static When<bool> IsTrue(this WhenIs<bool> whenIs) =>  whenIs._ToWhen(sbj=>sbj);
        
        /// <summary>
        /// Determines whether the subject boolean value is false.
        /// </summary>
        /// <param name="whenIs">The <see cref="WhenIs{bool}"/> instance.</param>
        /// <returns>A <see cref="When{bool}"/> indicating if the value is false.</returns>
        public static When<bool> IsFalse(this WhenIs<bool> whenIs) => whenIs._ToWhen(sbj => !sbj);
    }
}
