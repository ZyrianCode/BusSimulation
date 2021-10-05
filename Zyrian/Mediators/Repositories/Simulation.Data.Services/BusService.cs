using System.Collections.Generic;
using Simulation.Data.Repositories.Abstract;
using Simulation.Data.Services.Abstract;
using Simulation.Domain.Models;
using Simulation.Mappers;

namespace Simulation.Data.Services
{
    /// <summary>
    /// Сервис, взаимодействующий с репозиторием автобусов
    /// </summary>
    public class BusService : IBusServiceProvider
    {
        private readonly IBusRepositoryProvider _busRepository;

        public BusService(IBusRepositoryProvider busRepository)
        {
            _busRepository = busRepository;
        }

        public void AddBus(Bus busModel)
        {
            _busRepository.AddBus(busModel.ToEntity());
        }

        public void RemoveBusById(string id)
        {
            _busRepository.RemoveBusById(id);
        }

        public Bus GetBusById(string id)
        {
            return _busRepository.GetBusById(id).ToDomain();
        }

        public void UpdateBus(Bus busModel)
        {
            _busRepository.UpdateBus(busModel.ToEntity());
        }

        public List<Bus> CloneRepository()
        {
            return _busRepository.Clone().ToDomain();
        }

        public List<string> GetExistedIdList()
        {
            return _busRepository.GetExistedIdList();
        }

        public void Clear()
        {
            _busRepository.Clear();
        }
    }
}
