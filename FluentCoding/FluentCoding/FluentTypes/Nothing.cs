using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("FluentCodingTest")]
namespace FluentCoding
{
    public readonly struct Nothing
    {
        public static readonly Nothing SoftNull = new ();
    }
}
