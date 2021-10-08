
namespace BusSimulation.Models
{
    public class BusWpfModel : IWpfEntity
    {
        public string Number { get; set; }
        public string ModelName { get; set; }
        public string NumberOfRoute { get; set; }
        public string DriverName { get; set; }
        public string Description { get; set; }

    }
}
