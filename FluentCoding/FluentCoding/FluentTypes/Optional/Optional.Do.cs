using System.Diagnostics.Contracts;

namespace FluentCoding
{

    public readonly partial struct Optional<O>
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

            if (!_isSomething) return this;

            foreach (var doOnSubject in actionsToApplyOnSubject)
                doOnSubject(_subject);

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
            if (!_isSomething) return this;

            foreach (var mapOnSubject in functionsToApplyOnSubject)
                mapOnSubject(_subject);

            return this;
        }

    }

}
