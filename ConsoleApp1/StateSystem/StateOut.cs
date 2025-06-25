using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StateSystem
{
    class StateOut : StateText
    {
        public StateOut(string text, bool skipline) : base(text, skipline)
        {
        }
    }
}
