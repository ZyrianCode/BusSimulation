using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusSimulation.Models;
using Simulation.Data.Repositories.Entities.Abstract;
using Simulation.Data.Repositories.Mappers;
using Simulation.Domain.Models.Abstract;

namespace BusSimulation.WpfMappers
{
    public static class WpfMapper
    {
        private static readonly WpfEntitySelector WpfEntitySelector = new();
        /// <summary>
        /// Метод конвертации доменного объекта в сущность WPF
        /// </summary>
        /// <param name="domainEntity"> доменный объект </param>
        /// <returns></returns>
        public static IWpfEntity ToWpfEntity(this IDomainEntity domainEntity)
        {
            return WpfEntitySelector.SelectEntity(domainEntity);
        }

        /// <summary>
        /// Метод конвертации сущности WPF в доменный объект
        /// </summary>
        /// <param name="wpfEntity"> сущность репозитория </param>
        /// <returns></returns>
        public static IDomainEntity ToDomainEntity(this IWpfEntity wpfEntity)
        {
            return WpfEntitySelector.SelectEntity(wpfEntity);
        }
    }
}
