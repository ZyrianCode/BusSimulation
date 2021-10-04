using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Instruments.Randomization;
using Models.Domain;
using Models.Game;
using Models.WPF;

namespace Mappers
{
    /// <summary>
    /// Предоставляет методы-расширения для конвертации автобусов в сущность и в типы, унаследованные от доменных типов
    /// </summary>
    public static class BusMapper
    {
        /// <summary>
        /// Метод конвертации доменного объекта в сущность репозитория
        /// </summary>
        /// <param name="bus"> доменный объект </param>
        /// <returns></returns>
        public static BusEntity ToEntity(this Bus bus)
        {
            return new BusEntity
            {
                Number = bus.Number,
                ModelName = bus.ModelName,
                NumberOfRoute = bus.NumberOfRoute,
                DriverName = bus.DriverName,

                Id = new RandomIdGenerator().GenerateId(),
                CreationDate = DateTime.Now
            };
        }

        /// <summary>
        /// Метод конвертации сущности репозитория в доменный объект
        /// </summary>
        /// <param name="busEntity"> сущность репозитория </param>
        /// <returns></returns>
        public static Bus ToDomain(this BusEntity busEntity)
        {
            return new Bus
            {
                Number = busEntity.Number,
                ModelName = busEntity.ModelName,
                NumberOfRoute = busEntity.NumberOfRoute,
                DriverName = busEntity.DriverName
            };
        }

        /// <summary>
        /// Метод конвертации списка сущности репозитория в список доменных объектов
        /// </summary>
        /// <param name="busEntities"> список сущности репозитория </param>
        /// <returns></returns>
        public static List<Bus> ToDomain(this List<BusEntity> busEntities)
        {
            return busEntities.Select(busEntity => busEntity.ToDomain()).ToList();
        }
    }
}
