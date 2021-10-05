using System.Collections.Generic;
using System.Linq;
using Simulation.Data.Repositories.Entities.Abstract;
using Simulation.Data.Repositories.Repositories.Abstract;

namespace Simulation.Data.Repositories.Repositories
{
    /// <summary>
    /// Репозиторий, хранящий сущности
    /// </summary>
    public class Repository : IRepository
    {
        private static readonly List<IBaseRepositoryEntity> Entities = new();

        public void Add(IBaseRepositoryEntity entity)
        {
            Entities.Add(entity);
        }

        public void RemoveById(string id)
        {
            Entities.Remove(GetById(id));
        }

        public IBaseRepositoryEntity GetById(string id)
        {
            return Entities.Find(entity => entity.Id.Equals(id));
        }

        public void Update(IBaseRepositoryEntity entity)
        {
            RemoveById(entity.Id);
            Entities.Add(entity);
        }

        public List<IBaseRepositoryEntity> Clone()
        {
            return Entities;
        }

        public List<string> GetExistedIdList()
        {
            return Entities.Select(entity => entity.Id).ToList();
        }

        public void Clear()
        {
            Entities.Clear();
        }
    }
}
