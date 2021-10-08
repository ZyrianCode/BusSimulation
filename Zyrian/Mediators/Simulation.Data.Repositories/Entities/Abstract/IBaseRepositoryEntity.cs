using System;
using Simulation.Domain.Models.Abstract;

namespace Simulation.Data.Repositories.Entities.Abstract
{
    /// <summary>
    /// Интерфейс, предоставляющий сущности параметры, необходимые для поиска/удаления/обновления сущности в репозитории
    /// </summary>
    public interface IBaseRepositoryEntity : IDomainEntity
    {
        public string Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
