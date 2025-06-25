using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StateSystem
{
    abstract class StateText
    {
        public string Text { get; set; }
        public bool SkipLine { get; set; }

        public StateText(string text, bool skipline)
        {
            Text = text;
            SkipLine = skipline;
        }
    }
}
