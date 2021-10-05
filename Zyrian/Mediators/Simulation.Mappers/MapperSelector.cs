using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.Domain.Models;
using Simulation.Domain.Models.Abstract;
using Simulation.Repository.Entities;
using Simulation.Repository.Entities.Abstract;

namespace Simulation.Mappers
{
    public class MapperSelector
    {
        public IBaseRepositoryEntity SelectMapper(IDomainEntity domainEntity)
        {
            if (domainEntity is Bus bus)
            {
                return new BusRepositoryEntity()
                {
                    Number = bus.Number,
                    ModelName = bus.ModelName,
                    NumberOfRoute = bus.NumberOfRoute,
                    DriverName = bus.DriverName
                };
            }

            return new ParkingRepositoryEntity
            {
                BusStation = (domainEntity as Parking)?.BusStation
                    .Select(busEntity => busEntity.ToRepositoryEntity())
                    .Cast<BusRepositoryEntity>().ToList()
            };
        }

        public IDomainEntity SelectMapper(IBaseRepositoryEntity repositoryEntity)
        {
            if (repositoryEntity is BusRepositoryEntity busRepositoryEntity)
            {
                return new Bus()
                {
                    Number = busRepositoryEntity.Number,
                    ModelName = busRepositoryEntity.ModelName,
                    NumberOfRoute = busRepositoryEntity.NumberOfRoute,
                    DriverName = busRepositoryEntity.DriverName
                };
            }

            return new Parking
            {
                BusStation = (repositoryEntity as ParkingRepositoryEntity)?.BusStation
                    .Select(busEntity => busEntity.ToDomain())
                    .Cast<Bus>().ToList()
            };
        }
    }
}
