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
        public StateOut TextOut { get; set; }
        public StateIn TextIn { get; set; }

        public State(string name, StateOut textOut, StateIn textIn)
        {
            Name = name;
            TextOut = textOut;
            TextIn = textIn;
        }
        public void Show()
        {
            System.Console.Clear();
            System.Console.Title = Name;
            if (TextOut.SkipLine)
            {
                System.Console.WriteLine(TextOut.Text);
            }
            else
            {
                System.Console.Write(TextOut.Text);
            }
            if (TextIn.SkipLine)
            {
                System.Console.WriteLine(TextIn.Text);
                System.Console.ReadLine();
            }
            else
            {
                System.Console.Write(TextIn.Text);
                System.Console.ReadLine();
            }
        }
    }
}
