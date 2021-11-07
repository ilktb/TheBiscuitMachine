using System;

namespace BuiscitMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            IMachine machine = new Machine();
            machine.Start();
        }
    }
}
