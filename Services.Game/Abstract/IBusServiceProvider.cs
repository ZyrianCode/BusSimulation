using System.Collections.Generic;
using Models.Domain;

namespace Data.Services.Abstract
{
    /// <summary>
    /// Provider - интерфейс, предоставляющий интерфейс взаимодействия с сервисом репозитория
    /// </summary>
    public interface IBusServiceProvider
    {
        public void AddBus(Bus busModel);
        public void RemoveBusById(string id);
        public Bus GetBusById(string id);
        public void UpdateBus(Bus busModel);
        public List<Bus> CloneRepository();
        public List<string> GetExistedIdList();
        public void Clear();
    }
}
