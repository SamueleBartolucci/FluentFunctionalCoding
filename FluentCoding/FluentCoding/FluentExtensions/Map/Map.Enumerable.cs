using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Apply the mapping function on each item from subject and return the ienumerable projection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subjectsToMap"></param>
        /// <param name="mapFunc"></param>
        /// <returns></returns>
        public static IEnumerable<K> MapAll<T, K>(this IEnumerable<T> subjectsToMap, Func<T, K> mapFunc) 
            => subjectsToMap == null ? default : subjectsToMap.Select(mapFunc);
    }
}
