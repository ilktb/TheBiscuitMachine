using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuiscitMachine
{

    public interface IMachine
    {
        void Start();
        void Stop();
        void Pause();
        void UnPause();
        void OvenTempController();
    }
}
