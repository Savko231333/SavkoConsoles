using ConsoleApp1.StateSystem;

namespace Console;

class Program
{
    static void Main(string[] args)
    {
        StatesReader reader = new StatesReader();

        State StartState = reader.ReadState("ConsoleApp1\\States\\Start.xml");

        StartState.Show();
    }
}