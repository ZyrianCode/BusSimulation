using System.Linq;
using Simulation.Data.Repositories.Entities;
using Simulation.Data.Repositories.Entities.Abstract;
using Simulation.Domain.Models;
using Simulation.Domain.Models.Abstract;

namespace Simulation.Data.Repositories.Mappers
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
