using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Domain;

namespace Data.Services.Abstract
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
