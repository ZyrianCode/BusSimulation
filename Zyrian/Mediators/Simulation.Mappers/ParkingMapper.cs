using System;
using System.Collections.Generic;
using System.Linq;
using Simulation.Domain.Models;
using Simulation.Instruments.Randomization;
using Simulation.Repository.Entities;

namespace Simulation.Mappers
{
    /// <summary>
    /// Предоставляет методы-расширения для конвертации парковок в сущность и в типы, унаследованные от доменных типов
    /// </summary>
    public static class ParkingMapper
    {
        /// <summary>
        /// Метод конвертации доменного объекта в сущность репозитория
        /// </summary>
        /// <param name="parkingModel"> доменный объект </param>
        /// <returns></returns>
        public static ParkingEntity ToEntity(this Parking parkingModel)
        {
            return new ParkingEntity
            {
                BusStation = parkingModel.BusStation.Select(busModel => busModel.ToEntity()).ToList(),

                //Id = new RandomIdGenerator().GenerateId(),
                //CreationDate = DateTime.Now
            };
        }

        /// <summary>
        /// Метод конвертации сущности репозитория в доменный объект
        /// </summary>
        /// <param name="parkingEntity"> сущность репозитория </param>
        /// <returns></returns>
        public static Parking ToDomain(this ParkingEntity parkingEntity)
        {
            return new Parking
            {
                BusStation = parkingEntity.BusStation.Select(busEntity => busEntity.ToDomain()).ToList()
            };
        }

        /// <summary>
        /// Метод конвертации списка сущности репозитория в список доменных объектов
        /// </summary>
        /// <param name="parkingEntities"> список сущности репозитория </param>
        /// <returns></returns>
        public static List<Parking> ToDomain(this List<ParkingEntity> parkingEntities)
        {
            return parkingEntities.Select(parkingEntity => parkingEntity.ToDomain()).ToList();
        }
    }
}
