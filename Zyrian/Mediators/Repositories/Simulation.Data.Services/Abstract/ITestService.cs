using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.Domain.Models.Abstract;

namespace Simulation.Data.Services.Abstract
{
    public interface ITestService<TDomainModel> where TDomainModel : IDomainEntity
    {
        public void Add(TDomainModel domainModel);
        public void RemoveById(string id);
        public TDomainModel GetById(string id);
        public void Update(TDomainModel domainModel);
        public List<TDomainModel> CloneRepository();
        public List<string> GetExistedIdList();
        public void Clear();
    }
}
