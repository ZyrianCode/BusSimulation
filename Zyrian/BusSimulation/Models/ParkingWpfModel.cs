
using System.Collections.Generic;
using Simulation.Domain.Models.Abstract;

namespace BusSimulation.Models
{
    public class ParkingWpfModel : IWpfEntity
    {
        public string ParkingName { get; set; }
        public string Description { get; set; }
        public ICollection<BusWpfModel> BusStation { get; set; }
    }
}
