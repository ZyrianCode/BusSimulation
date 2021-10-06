using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.Data.Repositories.Services.Abstract;
using Simulation.Domain.Models;
using Simulation.Domain.Models.Abstract;
using Simulation.Game.Events;

namespace Simulation.Game
{
    public class Game
    {
        private readonly IRepositoryService<IDomainEntity> _repository;
        private List<string> _idList;
        private ParkingGameModel _parking;
        private List<BusGameModel> _busesOnTheWay = new();

        private event EventHandler<BusEventArgs> BusLeaved;
        private event EventHandler<BusEventArgs> BusArrived;

        public Game(IRepositoryService<IDomainEntity> repository)
        {
            _repository = repository;
        }

        public void Start()
        {
            ReceiveIdList();
            LoadEntities();

        }

        private void ReceiveIdList() => _idList = _repository.GetExistedIdList();

        private string GetIdFromList() => _idList.First();

        private void LoadEntities()
        {
            _parking = _repository.GetById(GetIdFromList()) as ParkingGameModel;
        }

        private void BusLeavesParkingAction()
        {
            BusGameModel bus = _parking.BusStation[new Random().Next(0, _parking.BusStation.Count)] as BusGameModel;
            _busesOnTheWay.Add(bus);
            _parking.BusStation.Remove(bus);

            PrintInfo();
            BusLeaved?.Invoke(this, new BusEventArgs(bus));
            BusLeaved -= OnBusLeavedLog;
        }

        private void BusArrivesToParkingAction()
        {
            BusGameModel bus = _busesOnTheWay[new Random().Next(0, _parking.BusStation.Count)];
            _parking.BusStation.Add(bus);
            _busesOnTheWay.Remove(bus);

            PrintInfo();
            BusArrived?.Invoke(this, new BusEventArgs(bus));
            BusArrived -= OnBusArrivedLog;
        }

        private void PrintInfo()
        {
            BusArrived += OnBusArrivedLog;
            BusLeaved += OnBusLeavedLog;
        }

        private void OnBusArrivedLog(object sender, BusEventArgs eventArgs)
        {
            Console.WriteLine($"Автобус {eventArgs.Bus.NumberOfRoute} модели {eventArgs.Bus.ModelName} " +
                              $"с номером {eventArgs.Bus.Number} прибыл на стоянку! ");
        }

        private void OnBusLeavedLog(object sender, BusEventArgs eventArgs)
        {
            Console.WriteLine($"Автобус {eventArgs.Bus.NumberOfRoute} модели {eventArgs.Bus.ModelName} " +
                              $"с номером {eventArgs.Bus.Number} выехал со стоянки! ");
        }
    }
}
