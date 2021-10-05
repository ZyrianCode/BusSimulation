using Simulation.Instruments.Randomization;
using System;

namespace Simulation.Repository.Entities.Abstract
{
    /// <summary>
    /// Базовая сущность репозитория, хранимая в репозитории.
    /// </summary>
    public abstract class BaseEntity : IBaseEntity
    {
        private static readonly IRandomIdGenerator IdGenerator = new RandomIdGenerator();

        public string Id { get; set; } = IdGenerator.GenerateId();
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
