using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TextProcessApp.Helpers
{
    public abstract class BaseTextFormatter
    {
        public abstract string ReturnFormattedContent(string filepath);
    }
}