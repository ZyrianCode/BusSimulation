using System.Collections.Generic;

namespace Simulation.Game.Models
{
    public class ParkingGameModel : IGameEntity
    {
        public List<BusGameModel> BusStation = new();
    }
}
