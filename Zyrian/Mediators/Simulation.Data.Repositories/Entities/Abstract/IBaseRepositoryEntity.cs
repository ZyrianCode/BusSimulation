using System;

namespace Simulation.Data.Repositories.Entities.Abstract
{
    /// <summary>
    /// Интерфейс, предоставляющий сущности параметры, необходимые для поиска/удаления/обновления сущности в репозитории
    /// </summary>
    public interface IBaseRepositoryEntity
    {
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
