using System;
using System.Collections.Generic;
using Simulation.Game.Events;
using Simulation.Game.Models;

namespace Simulation.Game.Scenarios
{
    public class SceneActions
    {
        private readonly ParkingGameModel _parking;
        private readonly List<BusGameModel> _busesOnTheWay;

        private event EventHandler<BusEventArgs> BusLeaved;
        private event EventHandler<BusEventArgs> BusArrived;

        public SceneActions(ParkingGameModel parking, List<BusGameModel> busesOnTheWay)
        {
            _parking = parking;
            _busesOnTheWay = busesOnTheWay;
        }

        public void BusLeavesParkingAction()
        {
            BusGameModel bus = _parking.BusStation[new Random().Next(0, _parking.BusStation.Count)];
            _busesOnTheWay.Add(bus);
            _parking.BusStation.Remove(bus);

            PrintInfo();
            BusLeaved?.Invoke(this, new BusEventArgs(bus));
            BusLeaved -= OnBusLeavedLog;
        }

        public void BusArrivesToParkingAction()
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
