using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation.Game.Events
{
    public class BusEventArgs : EventArgs
    {
       public BusGameModel Bus { get; set; }

       public BusEventArgs(BusGameModel bus)
       {
           Bus = bus;
       }
    }
}
