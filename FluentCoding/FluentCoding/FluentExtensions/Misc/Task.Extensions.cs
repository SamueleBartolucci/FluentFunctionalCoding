using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentCoding
{
    public static partial class MiscExtensions
    {
        public static Task<T> ToTask<T>(this T toWrapInTask) => Task.FromResult(toWrapInTask);
    }
}
