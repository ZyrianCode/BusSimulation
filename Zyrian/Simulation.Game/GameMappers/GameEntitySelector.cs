using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.Domain.Models;
using Simulation.Domain.Models.Abstract;
using Simulation.Game.Events;
using Simulation.Game.Models;

namespace Simulation.Game.GameMappers
{
    public class GameEntitySelector
    {
        public IDomainEntity SelectEntity(IGameEntity gameEntity)
        {
            if (gameEntity is BusGameModel busGameModel)
            {
                return new Bus()
                {
                    Number = busGameModel.Number,
                    ModelName = busGameModel.ModelName,
                    NumberOfRoute = busGameModel.NumberOfRoute,
                    DriverName = busGameModel.DriverName
                };
            }

            return new Parking()
            {
                BusStation = (gameEntity as ParkingGameModel)?.BusStation
                    .Select(busEntity => busEntity.ToDomainEntity())
                    .Cast<Bus>().ToList()
            };
        }

        public IGameEntity SelectEntity(IDomainEntity domainEntity)
        {
            if (domainEntity is Bus bus)
            {
                return new BusGameModel()
                {
                    Number = bus.Number,
                    ModelName = bus.ModelName,
                    NumberOfRoute = bus.NumberOfRoute,
                    DriverName = bus.DriverName
                };
            }

            return new ParkingGameModel()
            {
                BusStation = (domainEntity as Parking)?.BusStation
                    .Select(busEntity => busEntity.ToGameEntity())
                    .Cast<BusGameModel>().ToList()
            };
        }
    }
}
