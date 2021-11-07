using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuiscitMachine
{
    public interface IBelt
    {
        void Next();
        void CleanBelt();
    }
}
