using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace BuiscitMachine
{
    public class Machine : IMachine
    {
        private int temp;
        private bool shouldDecrement;
        private bool stop;
        private bool paused;
        private IBelt belt;
        private ConsoleKey Key { get; set; }

        public Machine()
        {
            belt = new Belt();
        }
        public void Pause()
        {
            paused = true;
        }

        public void UnPause()
        {
            paused = false;
        }

        public void Stop()
        {
            stop = true;
            belt.CleanBelt();
        }

        public void Start()
        {
            OvenTempController();
            Console.WriteLine("The oven is heating. The temperature is still under 220C. It takes about 5 seconds...");

            while (true)
            {
                if (temp >= 220 && temp <= 240)
                {
                    if (Console.KeyAvailable) Key = Console.ReadKey(true).Key;
                    ExecuteComand();

                    if (stop) break;

                    Thread.Sleep(1000); //Only for the purpose of more readable visualization of the result.

                    if (paused == false)
                    {
                        belt.Next();
                    }
                    Console.WriteLine($"curTemp:{temp}\n");
                }
            }
        }        

        public void OvenTempController()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    if (stop) break;
                    Thread.Sleep(10); // in milliseconds
                    if (temp == 240)
                        shouldDecrement = true;
                    else if (temp == 220)
                        shouldDecrement = false;

                    if (!shouldDecrement)
                        temp++;
                    else
                        temp--;

                }
            });
        }
        private void ExecuteComand()
        {

            switch (Key)
            {
                case ConsoleKey.S:
                    Stop();
                    break;
                case ConsoleKey.P:
                    Pause();
                    break;
                case ConsoleKey.U:
                    UnPause();
                    break;
                default:
                    break;
            }
        }

    }
}
