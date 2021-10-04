using System.Collections.Generic;
using Simulation.Domain.Models;

namespace Simulation.Data.Services.Abstract
{
    public interface IParkingServiceProvider
    {
        public void AddParking(Parking parkingModel);
        public void RemoveParkingById(string id);
        public Parking GetParkingById(string id);
        public void UpdateParking(Parking parkingModel);
        public List<Parking> CloneRepository();
        public List<string> GetExistedIdList();
        public void Clear();
    }
}
