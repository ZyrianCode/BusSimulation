using System.Collections.Generic;
using System.Linq;
using Simulation.Data.Repositories.Entities.Abstract;
using Simulation.Domain.Models.Abstract;

namespace Simulation.Data.Repositories.Mappers
{
    public static class Mapper
    {
        private static readonly MapperSelector MapperSelector = new();
        /// <summary>
        /// Метод конвертации доменного объекта в сущность репозитория
        /// </summary>
        /// <param name="domainModel"> доменный объект </param>
        /// <returns></returns>
        public static IBaseRepositoryEntity ToRepositoryEntity(this IDomainEntity domainModel)
        {
            return MapperSelector.SelectMapper(domainModel);
        }

        /// <summary>
        /// Метод конвертации сущности репозитория в доменный объект
        /// </summary>
        /// <param name="repositoryEntity"> сущность репозитория </param>
        /// <returns></returns>
        public static IDomainEntity ToDomain(this IBaseRepositoryEntity repositoryEntity)
        {
            return MapperSelector.SelectMapper(repositoryEntity);
        }

        /// <summary>
        /// Метод конвертации списка сущности репозитория в список доменных объектов
        /// </summary>
        /// <param name="repository"> список сущности репозитория </param>
        /// <returns> список сущностей домена </returns>
        public static List<IDomainEntity> ToDomain(this List<IBaseRepositoryEntity> repository)
        {
            return repository.Select(repositoryEntity => repositoryEntity.ToDomain()).ToList();
        }
    }
}
