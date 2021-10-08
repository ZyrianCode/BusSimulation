using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.Game.Models;

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
