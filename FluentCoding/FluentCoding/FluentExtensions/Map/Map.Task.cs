using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding.FluentExtensions.Map
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Apply the mapping function on the subject and return the result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subjectToMap"></param>
        /// <param name="mapFunc"></param>
        /// <returns></returns>
        public static async Task<K> MapAsync<T, K>(this Task<T> subjectToMap, Func<T, K> mapFunc) 
            => (await subjectToMap).Map(mapFunc);

    }
}
