using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Language
{
    interface ILanguage
    {
        string main { get; }
        string test { get; }
    }

    public class Language_CN : ILanguage
    {

    }
}
