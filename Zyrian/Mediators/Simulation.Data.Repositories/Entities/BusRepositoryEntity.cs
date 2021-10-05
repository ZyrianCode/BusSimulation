using Simulation.Data.Repositories.Entities.Abstract;

namespace Simulation.Data.Repositories.Entities
{
    public class BusRepositoryEntity : RepositoryEntity
    {
        public string Number { get; set; }
        public string ModelName { get; set; }
        public string NumberOfRoute { get; set; }
        public string DriverName { get; set; }
    }
}
