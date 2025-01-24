﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding.FluentExtensions.Map
{
    public static partial class FluentExtension
    {
        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRight bool is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRight"></param>
        /// <returns></returns>
        public static async Task<T> OrAsync<T>(this Task<T> leftValue, T orRightValue, bool chooseRight = false)
            => (await leftValue).Or(orRightValue, chooseRight);


        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRightWhen() is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static async Task<T> OrAsync<T>(this Task<T> leftValue, T orRightValue, Func<bool> chooseRightWhen)
            => (await leftValue).Or(orRightValue, chooseRightWhen);

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRightWhen(leftValue) is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static async Task<T> OrAsync<T>(this Task<T> leftValue, T orRightValue, Func<T, bool> chooseRightWhen)
           => (await leftValue).Or(orRightValue, chooseRightWhen);


        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRight bool is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRight"></param>
        /// <returns></returns>
        public static async Task<T> OrAsync<T>(this Task<T> leftValue, Func<T> orRightValue, bool chooseRight = false)
            => (await leftValue).Or(orRightValue, chooseRight);


        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRightWhen() is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static async Task<T> OrAsync<T>(this Task<T> leftValue, Func<T> orRightValue, Func<bool> chooseRightWhen)
            => (await leftValue).Or(orRightValue, chooseRightWhen);

        /// <summary>
        /// Choose between the left or the right value.
        /// Pick left when not null and chooseRightWhen(leftValue) is false
        /// Empty string is considered NOT null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="leftValue"></param>
        /// <param name="orRightValue"></param>
        /// <param name="chooseRightWhen"></param>
        /// <returns></returns>
        public static async Task<T> OrAsync<T>(this Task<T> leftValue, Func<T> orRightValue, Func<T, bool> chooseRightWhen)
           => (await leftValue).Or(orRightValue, chooseRightWhen);

    }
}
