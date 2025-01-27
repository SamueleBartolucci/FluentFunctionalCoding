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
        /// Apply a set of actions to the subject (when this is not null) and then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subject"></param>
        /// <param name="actionsToApplyOnSubject"></param>
        /// <returns></returns>
        public static T Do<T>(this T subject, params Action<T>[] actionsToApplyOnSubject)
        {
            if (subject == null) return default;

            foreach (var doOnSubject in actionsToApplyOnSubject)
                doOnSubject(subject);

            return subject;
        }



        /// <summary>
        /// Apply a set of functions to the subject (when this is not null) and then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subject"></param>
        /// <param name="functionsToApplyOnSubject"></param>
        /// <returns></returns>
        public static T Do<T, K>(this T subject, params Func<T,K>[] functionsToApplyOnSubject)
        {
            if (subject == null) return default;

            foreach (var mapOnSubject in functionsToApplyOnSubject)
                mapOnSubject(subject);

            return subject;
        }
    }
}
