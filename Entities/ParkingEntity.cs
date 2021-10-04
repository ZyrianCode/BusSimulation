using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities
{
    /// <summary>
    /// Сущность парковка - хранится в репозитории парковок
    /// </summary>
    public class ParkingEntity : BaseEntity
    {
        public List<BusEntity> BusStation = new();
    }
}
