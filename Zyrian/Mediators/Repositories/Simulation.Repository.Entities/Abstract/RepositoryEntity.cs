using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.Instruments.Randomization;

namespace Simulation.Repository.Entities.Abstract
{
    public abstract class RepositoryEntity : IBaseRepositoryEntity
    {
        private static readonly IRandomIdGenerator IdGenerator = new RandomIdGenerator();
        public string Id { get; set; } = IdGenerator.GenerateId();
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
