using System.Collections.Generic;
using Simulation.Data.Repositories.Entities.Abstract;

namespace Simulation.Data.Repositories.Entities
{
    public class ParkingRepositoryEntity : RepositoryEntity
    {
        public List<BusRepositoryEntity> BusStation{ get; set; }
    }
}
