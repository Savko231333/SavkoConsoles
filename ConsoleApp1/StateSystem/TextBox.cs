using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StateSystem
{
    class TextBox : Text
    {
        public bool SkipLine { get; set; }
        public TextBox(string text, bool skipline) : base(text)
        {
            SkipLine = skipline;
        }
        public TextBox()
        {
        }
    }
}
