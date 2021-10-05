using System.Collections.Generic;
using System.Linq;
using Simulation.Data.Repositories.Mappers;
using Simulation.Data.Repositories.Repositories.Abstract;
using Simulation.Data.Repositories.Services.Abstract;
using Simulation.Domain.Models.Abstract;


namespace Simulation.Data.Repositories.Services
{
    public class TestService<TDomainModel> : ITestService<TDomainModel> where TDomainModel : IDomainEntity 
    {
        private readonly IRepository _repository;

        public TestService(IRepository repository)
        {
            _repository = repository;
        }
        public void Add(TDomainModel domainModel)
        {
            _repository.Add(domainModel.ToRepositoryEntity());
        }

        public void RemoveById(string id)
        {
            _repository.RemoveById(id);
        }

        public TDomainModel GetById(string id)
        {
            return (TDomainModel)_repository.GetById(id).ToDomain();
        }

        public void Update(TDomainModel domainModel)
        {
            _repository.Update(domainModel.ToRepositoryEntity());
        }

        public List<TDomainModel> CloneRepository()
        {
            return _repository.Clone().ToDomain().Cast<TDomainModel>().ToList();
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
