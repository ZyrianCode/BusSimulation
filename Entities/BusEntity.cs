using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Abstract;

namespace Entities
{
    /// <summary>
    /// Сущность автобус, хранится в репозитории автобусов
    /// </summary>
    public class BusEntity : BaseEntity
    {
        public string Number { get; set; }
        public string ModelName { get; set; }
        public string NumberOfRoute { get; set; }
        public string DriverName { get; set; }
    }
}
