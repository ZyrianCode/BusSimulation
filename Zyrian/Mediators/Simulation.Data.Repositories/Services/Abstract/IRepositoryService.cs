using System.Collections.Generic;
using Simulation.Domain.Models.Abstract;

namespace Simulation.Data.Repositories.Services.Abstract
{
    public interface IRepositoryService<TDomainEntity> where TDomainEntity : IDomainEntity
    {
        public void Add(TDomainEntity domainEntity);
        public void RemoveById(string id);
        public TDomainEntity GetById(string id);
        public void Update(TDomainEntity domainEntity);
        public List<TDomainEntity> CloneRepository();
        public List<string> GetExistedIdList();
        public void Clear();
    }
}
