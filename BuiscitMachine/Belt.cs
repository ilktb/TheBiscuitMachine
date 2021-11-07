using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuiscitMachine
{
    public class Belt : IBelt
    {
        private ICollection<Biscuit> belt;
        public ICollection<Biscuit> basket { get; set; }

        public Belt()
        {
            belt = new List<Biscuit>();
            basket = new List<Biscuit>();
        }

        public void Next()
        {
            if (belt.Count < 5)
                belt.Add(new Biscuit());
            else if (belt.Count >= 5)
            {
                belt.Add(new Biscuit());

                var ready = belt.Last();

                basket.Add(ready);
                belt.Remove(ready);
            }
            BiscuitStaedInit(false);
        }

        public void CleanBelt()
        {
            for (int i = 0; i < belt.Count; i++)
            {
                var ready = belt.Last();

                basket.Add(ready);
                belt.Remove(ready);
                BiscuitStaedInit(true);

                Thread.Sleep(1000); //Only for the purpose of more readable visualization of the result.
            }
        }

        /// <summary>
        /// Initialzes the state of each biscut with each rotation
        /// </summary>
        private void BiscuitStaedInit(bool reverce)
        {
            if (!reverce)
            {
                for (int i = 0; i < belt.Count; i++)
                {
                    belt.ElementAt(i).State = (BiscuitState)i;
                    Console.WriteLine(belt.ElementAt(i).State);
                }
            }
            else
            {
                Console.WriteLine("\nThe machine has been stopped. Cleaning the belt...");
                for (int i = 0, j = 4; j > 4 - (belt.Count); j--, i++)
                {
                    belt.ElementAt(i).State = (BiscuitState)j;
                    Console.WriteLine(belt.ElementAt(i).State);
                }
            }
        }
    }
}
