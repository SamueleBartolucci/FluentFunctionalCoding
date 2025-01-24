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
        /// <param name="actionSubject"></param>
        /// <param name="actionsToApplyOnSubject"></param>
        /// <returns></returns>
        public static T Do<T>(this T actionSubject, params Action<T>[] actionsToApplyOnSubject)
        {
            if (actionSubject == null) return default;

            foreach (var doOnSubject in actionsToApplyOnSubject)
                doOnSubject(actionSubject);

            return actionSubject;
        }



        /// <summary>
        /// Apply a set of functions to the subject (when this is not null) and then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="actionSubject"></param>
        /// <param name="functionsToApplyOnSubject"></param>
        /// <returns></returns>
        public static T Do<T, K>(this T actionSubject, params Func<T,K>[] functionsToApplyOnSubject)
        {
            if (actionSubject == null) return default;

            foreach (var mapOnSubject in functionsToApplyOnSubject)
                mapOnSubject(actionSubject);

            return actionSubject;
        }
    }
}
