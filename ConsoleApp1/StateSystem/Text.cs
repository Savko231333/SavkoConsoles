using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StateSystem
{
    abstract class Text
    {
        public string Message { get; set; }
        public Text(string message)
        {
            Message = message;
        }
        public Text()
        {
            Message = "";
        }
    }
}
