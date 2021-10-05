using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.Repository.Entities.Abstract;

namespace Simulation.Repository.Entities
{
    public class BusRepositoryEntity : RepositoryEntity
    {
        public string Number { get; set; }
        public string ModelName { get; set; }
        public string NumberOfRoute { get; set; }
        public string DriverName { get; set; }
    }
}
