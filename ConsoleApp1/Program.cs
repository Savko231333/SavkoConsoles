using ConsoleApp1.StateSystem;

namespace Console;

class Program
{
    static void Main(string[] args)
    {
        StatesReader reader = new StatesReader();

        if (reader.ReadState("ConsoleApp1\\States\\Start.xml", out var StartState))
            StartState?.Show();
    }
}