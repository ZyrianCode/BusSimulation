using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Abstract
{
    /// <summary>
    /// Интерфейс, предоставляющий сущности параметры, необходимые для поиска/удаления/обновления сущности в репозитории
    /// </summary>
    public interface IBaseEntity
    {
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
