using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Data.Abstract
{
    
    public interface IBusRepositoryProvider
    {
        public void AddBus(BusEntity busEntity);

        public void RemoveBusById(string id);

        public BusEntity GetBusById(string id);

        public void UpdateBus(BusEntity busEntity);

        public List<BusEntity> Clone();

        public List<string> GetExistedIdList();

        public void Clear();
    }
}
