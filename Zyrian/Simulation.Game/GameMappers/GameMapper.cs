using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.Domain.Models.Abstract;
using Simulation.Game.Models;

namespace Simulation.Game.GameMappers
{
    public static class GameMapper
    {
        public static readonly GameEntitySelector GameEntitySelector = new ();

        public static IGameEntity ToGameEntity(this IDomainEntity domainEntity)
        {
            return GameEntitySelector.SelectEntity(domainEntity);
        }

        public static IDomainEntity ToDomainEntity(this IGameEntity gameEntity)
        {
            return GameEntitySelector.SelectEntity(gameEntity);
        }
    }
}
