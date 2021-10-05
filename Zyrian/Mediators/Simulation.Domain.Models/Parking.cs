using System.Collections.Generic;
using Simulation.Domain.Models.Abstract;

namespace Simulation.Domain.Models
{
    public class Parking : DomainEntity
    {
        public List<Bus> BusStation = new();
    }
}
