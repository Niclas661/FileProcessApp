using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextProcessApp.Helpers
{
    interface ITextFormatter
    {
        string ReturnFormattedContent(string filepath);
    }
}
