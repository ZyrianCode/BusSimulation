using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.Repository.Entities.Abstract;

namespace Simulation.Repository.Entities
{
    public class ParkingRepositoryEntity : RepositoryEntity
    {
        public List<BusRepositoryEntity> BusStation = new();
    }
}
