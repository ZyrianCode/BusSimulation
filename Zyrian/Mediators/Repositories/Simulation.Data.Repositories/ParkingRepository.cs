using System.Collections.Generic;
using Simulation.Data.Repositories.Abstract;
using Simulation.Repository.Entities;

namespace Simulation.Data.Repositories
{
    /// <summary>
    /// Репозиторий. Хранит сущности.
    /// </summary>
    public class ParkingRepository : IParkingRepositoryProvider
    {
        private static readonly List<ParkingEntity> Parkings = new();

        public void AddParking(ParkingEntity parkingEntity)
        {
            Parkings.Add(parkingEntity);
        }

        public void RemoveParkingById(string id)
        {
            Parkings.Remove(Parkings.Find(parkingEntity => parkingEntity.Id.Equals(id)));
        }

        public ParkingEntity GetParkingById(string id)
        {
            return Parkings.Find(parkingEntity => parkingEntity.Id.Equals(id));
        }

        public void UpdateParking(ParkingEntity parkingEntity)
        {
            Parkings.Remove(Parkings.Find(parking => parking.Id.Equals(parkingEntity.Id)));
            AddParking(parkingEntity);
        }

        public List<ParkingEntity> Clone()
        {
            return Parkings;
        }

        public List<string> GetExistedIdList()
        {
            var existedIdList = new List<string>();
            foreach (var parkingEntity in Parkings)
            {
                existedIdList.Add(parkingEntity.Id);
            }

            return existedIdList;
        }

        public void Clear()
        {
            Parkings.Clear();
        }
    }
}
