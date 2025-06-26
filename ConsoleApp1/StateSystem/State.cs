using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace ConsoleApp1.StateSystem
{
    class State
    {
        public string Name { get; set; }
        public TextLine TextOut { get; set; }
        public TextBox TextIn { get; set; }

        public State(string name, TextLine textOut, TextBox textIn)
        {
            Name = name;
            TextOut = textOut;
            TextIn = textIn;
        }
        public void Show()
        {
            System.Console.Clear();
            System.Console.Title = Name;

            
        }
    }
}
