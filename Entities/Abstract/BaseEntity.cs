using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    /// <summary>
    /// Базовая сущность репозитория, хранимая в репозитории.
    /// </summary>
    public abstract class BaseEntity : IBaseEntity
    {
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
