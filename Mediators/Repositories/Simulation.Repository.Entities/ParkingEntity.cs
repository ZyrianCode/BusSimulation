using System.Collections.Generic;
using Simulation.Repository.Entities.Abstract;

namespace Simulation.Repository.Entities
{
    /// <summary>
    /// Сущность парковка - хранится в репозитории парковок
    /// </summary>
    public class ParkingEntity : BaseEntity
    {
        public List<BusEntity> BusStation = new();
    }
}
