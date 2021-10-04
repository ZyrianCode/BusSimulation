using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.WPF
{
    interface IParkingCommandsProvider
    {
        public void AddBusToParking(BusWpfModel bus);
        public void RemoveBusFromParking(BusWpfModel bus);
        public BusWpfModel FindBus(BusWpfModel bus);
    }
}
