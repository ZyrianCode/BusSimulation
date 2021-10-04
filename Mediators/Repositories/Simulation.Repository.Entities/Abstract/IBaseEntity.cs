using System;

namespace Simulation.Repository.Entities.Abstract
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
