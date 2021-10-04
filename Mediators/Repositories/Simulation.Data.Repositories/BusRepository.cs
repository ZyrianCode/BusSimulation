using System.Collections.Generic;
using Simulation.Data.Repositories.Abstract;
using Simulation.Repository.Entities;

namespace Simulation.Data.Repositories
{
    public class BusRepository : IBusRepositoryProvider
    {
        private static readonly List<BusEntity> Buses = new();

        public void AddBus(BusEntity busEntity)
        {
            Buses.Add(busEntity);
        }

        public void RemoveBusById(string id)
        {
            Buses.Remove(Buses.Find(auto => auto.Id.Equals(id)));
        }

        public BusEntity GetBusById(string id)
        {
            return Buses.Find(auto => auto.Id.Equals(id));
        }

        public void UpdateBus(BusEntity busEntity)
        {
            Buses.Remove(Buses.Find(bus => bus.Id.Equals(busEntity.Id)));
            AddBus(busEntity);
        }

        public List<BusEntity> Clone()
        {
            return Buses;
        }

        public List<string> GetExistedIdList()
        {
            var existedIdList = new List<string>();
            foreach (var busEntity in Buses)
            {
                existedIdList.Add(busEntity.Id);
            }

            return existedIdList;
        }

        public void Clear()
        {
            Buses.Clear();
        }
    }
}
