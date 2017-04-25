using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TextProcessApp.Helpers
{
    /// <summary>
    /// This class uses classes from Windows Forms. This is a loophole to convert the raw content from an RTF file to a RichTextBox object 
    /// and from there grab the value from Text property
    /// </summary>
    public class RTFFormatter : BaseTextFormatter
    {
        string rawContent = null;
        /// <summary>
        /// TODO: Figure out how to convert RTF content to string
        /// </summary>
        /// <param name="filepath"></param>
        public string ReturnRTFContent(string filepath)
        {
            rawContent = System.IO.File.ReadAllText(filepath);

            RichTextBox rtfBox = new RichTextBox();
            rtfBox.Rtf = rawContent;
            string goodText = rtfBox.Text;
            goodText = Regex.Replace(goodText, "[\n\f]", " ");
            return goodText;
        }
    }
}