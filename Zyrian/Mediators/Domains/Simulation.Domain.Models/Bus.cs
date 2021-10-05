using Simulation.Domain.Models.Abstract;

namespace Simulation.Domain.Models
{
    public class Bus : DomainEntity
    {
        public string Number { get; set; }
        public string ModelName { get; set; }
        public string NumberOfRoute { get; set; }
        public string DriverName { get; set; }
    }
}
