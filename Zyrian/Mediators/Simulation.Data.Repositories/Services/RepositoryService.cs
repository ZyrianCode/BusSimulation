using System.Collections.Generic;
using System.Linq;
using Simulation.Data.Repositories.Entities.Abstract;
using Simulation.Data.Repositories.Mappers;
using Simulation.Data.Repositories.Repositories.Abstract;
using Simulation.Data.Repositories.Services.Abstract;
using Simulation.Domain.Models.Abstract;


namespace Simulation.Data.Repositories.Services
{
    public class RepositoryService<TDomainEntity> : IRepositoryService<TDomainEntity> where TDomainEntity : IDomainEntity 
    {
        private readonly IRepository _repository;

        public RepositoryService(IRepository repository)
        {
            _repository = repository;
        }
        public void Add(TDomainEntity domainEntity)
        {
            _repository.Add(domainEntity.ToRepositoryEntity());
        }

        public void RemoveById(string id)
        {
            _repository.RemoveById(id);
        }

        public TDomainEntity GetById(string id)
        {
            return (TDomainEntity)_repository.GetById(id).ToDomain();
        }

        public void Update(TDomainEntity domainEntity)
        {
            _repository.Update(domainEntity.ToRepositoryEntity());
        }

        public List<TDomainEntity> CloneRepository()
        {
            return _repository.Clone().ToDomain().Cast<TDomainEntity>().ToList();
        }

        public List<string> GetExistedIdList()
        {
            return _repository.GetExistedIdList();
        }

        public void Clear()
        {
            _repository.Clear();
        }
    }
}
