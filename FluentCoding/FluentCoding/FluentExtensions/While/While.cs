using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding.FluentExtensions.While
{
    public static partial class FluentExtension
    {
        public static T While<T>(Func<T> initializeWhileValue, Func<T, bool> valueIsTrueWhen, Func<T, T> funcOnValueWhileTrue)
        {
            var whileValue = initializeWhileValue();
            while (valueIsTrueWhen(whileValue))
                whileValue = funcOnValueWhileTrue(whileValue);
            return whileValue;
        }       
    }
}
