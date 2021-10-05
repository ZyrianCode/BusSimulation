using System;
using Simulation.Infrastructure.Instruments.Randomization;

namespace Simulation.Data.Repositories.Entities.Abstract
{
    public abstract class RepositoryEntity : IBaseRepositoryEntity
    {
        private static readonly IRandomIdGenerator IdGenerator = new RandomIdGenerator();
        public string Id { get; set; } = IdGenerator.GenerateId();
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
