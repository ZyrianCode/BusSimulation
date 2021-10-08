using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusSimulation.Models;
using Simulation.Data.Repositories.Entities;
using Simulation.Data.Repositories.Entities.Abstract;
using Simulation.Data.Repositories.Mappers;
using Simulation.Domain.Models;
using Simulation.Domain.Models.Abstract;

namespace BusSimulation.WpfMappers
{
    public class WpfEntitySelector
    {
        public IDomainEntity SelectEntity(IWpfEntity wpfEntity)
        {
            if (wpfEntity is BusWpfModel busWpfModel)
            {
                return new Bus()
                {
                    Number = busWpfModel.Number,
                    ModelName = busWpfModel.ModelName,
                    NumberOfRoute = busWpfModel.NumberOfRoute,
                    DriverName = busWpfModel.DriverName
                };
            }

            return new Parking
            {
                BusStation = (wpfEntity as ParkingWpfModel)?.BusStation
                    .Select(busEntity => busEntity.ToDomainEntity())
                    .Cast<Bus>().ToList()
            };
        }

        public IWpfEntity SelectEntity(IDomainEntity domainEntity)
        {
            if (domainEntity is Bus bus)
            {
                return new BusWpfModel()
                {
                    Number = bus.Number,
                    ModelName = bus.ModelName,
                    NumberOfRoute = bus.NumberOfRoute,
                    DriverName = bus.DriverName
                };
            }

            return new ParkingWpfModel()
            {
                BusStation = (domainEntity as Parking)?.BusStation
                    .Select(busEntity => busEntity.ToWpfEntity())
                    .Cast<BusWpfModel>().ToList()
            };
        }
    }
}
