using System.Diagnostics.Contracts;

namespace FluentCoding
{

    public abstract partial record Optional<O>
    {
        /// <summary>
        /// Apply a set of actions to the subject (when IsSome) and then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subject"></param>
        /// <param name="actionsToApplyOnSubject"></param>
        /// <returns></returns>
        public Optional<O> Do(params Action<O>[] actionsToApplyOnSubject)
        {
            if (this is OptionalJust<O>(var v))
                v.Do(actionsToApplyOnSubject);

            return this;
        }



        /// <summary>
        /// Apply a set of functions to the subject (when IsSome) and then return the subject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="K"></typeparam>
        /// <param name="subject"></param>
        /// <param name="functionsToApplyOnSubject"></param>
        /// <returns></returns>
        public Optional<O> Do<K>(params Func<O, K>[] functionsToApplyOnSubject)
        {
            if (this is OptionalJust<O>(var v))
                v.Do(functionsToApplyOnSubject);

            return this;
        }


    }

}
