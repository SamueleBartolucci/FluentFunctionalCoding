using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public interface IWhenIs<T>
    {
        /// <summary>
        /// Evaluates a condition and returns a `When<T>` instance if the condition is true.
        /// </summary>
        /// <param name="isTrue">The condition to evaluate.</param>
        /// <returns>A `When<T>` instance representing the result of the evaluation.</returns>
        IWhen<T> Is(bool isTrue);

        /// <summary>
        /// Evaluates multiple conditions and returns a `When<T>` instance if all conditions are true.
        /// </summary>
        /// <param name="predicates">An array of conditions to evaluate.</param>
        /// <returns>A `When<T>` instance representing the result of the evaluation.</returns>
        IWhen<T> Is(params Func<bool>[] predicates);

        /// <summary>
        /// Evaluates multiple conditions on the subject and returns a `When<T>` instance if all conditions are true.
        /// </summary>
        /// <param name="predicates">An array of conditions to evaluate on the subject.</param>
        /// <returns>A `When<T>` instance representing the result of the evaluation.</returns>
        IWhen<T> Is(params Func<T, bool>[] predicates);     
        

    }
}
