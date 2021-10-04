using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Abstract;
using Data.Services.Abstract;
using Entities;
using Mappers;
using Models.Domain;

namespace Data.Services
{
    public class ParkingService : IParkingServiceProvider
    {
        private readonly IParkingRepositoryProvider _parkingRepository;

        public ParkingService(IParkingRepositoryProvider parkingRepository)
        {
            _parkingRepository = parkingRepository;
        }

        public void AddParking(Parking parkingModel)
        {
            _parkingRepository.AddParking(parkingModel.ToEntity());
        }

        public void RemoveParkingById(string id)
        {
            _parkingRepository.RemoveParkingById(id);
        }

        public Parking GetParkingById(string id)
        {
            return _parkingRepository.GetParkingById(id).ToDomain();
        }

        public void UpdateParking(Parking parkingModel)
        {
            _parkingRepository.UpdateParking(parkingModel.ToEntity());
        }

        public List<Parking> CloneRepository()
        {
            return _parkingRepository.Clone().ToDomain();
        }

        public List<string> GetExistedIdList()
        {
            return _parkingRepository.GetExistedIdList();
        }

        public void Clear()
        {
            _parkingRepository.Clear();
        }
    }
}
