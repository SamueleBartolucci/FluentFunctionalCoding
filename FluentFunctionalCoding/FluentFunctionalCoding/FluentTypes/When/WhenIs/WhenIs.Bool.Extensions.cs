using FluentFunctionalCoding;

namespace FluentFunctionalCoding
{
    /// <summary>
    /// Provides extension methods for <c>WhenIs&lt;bool&gt;</c> to perform conditional checks on boolean values.
    /// </summary>
    public static partial class WhenIsExtension
    {
        /// <summary>
        /// Determines whether the subject boolean value is true.
        /// </summary>
        /// <param name="whenIs">The <c>WhenIs&lt;bool&gt;</c> instance.</param>
        /// <returns>A <c>When&lt;bool&gt;</c> indicating if the value is true.</returns>
        public static When<bool> IsTrue(this WhenIs<bool> whenIs) =>  whenIs._ToWhen(sbj=>sbj);
        
        /// <summary>
        /// Determines whether the subject boolean value is false.
        /// </summary>
        /// <param name="whenIs">The <c>WhenIs&lt;bool&gt;</c> instance.</param>
        /// <returns>A <c>When&lt;bool&gt;</c> indicating if the value is false.</returns>
        public static When<bool> IsFalse(this WhenIs<bool> whenIs) => whenIs._ToWhen(sbj => !sbj);
    }
}
