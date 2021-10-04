using System;

namespace Simulation.Repository.Entities.Abstract
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
