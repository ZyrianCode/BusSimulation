using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.Data.Repositories.Services.Abstract;
using Simulation.Domain.Models;
using Simulation.Domain.Models.Abstract;
using Simulation.Game.Events;
using Simulation.Game.Scenarios;

namespace Simulation.Game
{
    public class Game
    {
        private readonly IRepositoryService<IDomainEntity> _repository;
        private List<string> _idList;

        private ParkingGameModel _parking;
        private readonly List<BusGameModel> _busesOnTheWay = new();

        private SceneActions _sceneActions;

        public Game(IRepositoryService<IDomainEntity> repository)
        {
            _repository = repository;
        }

        public void Start()
        {
            ReceiveIdList();
            LoadEntities();
            _sceneActions = new(_parking, _busesOnTheWay);
            StartScenarios();
        }

        private void ReceiveIdList() => _idList = _repository.GetExistedIdList();

        private string GetIdFromList() => _idList.First();

        private void LoadEntities()
        {
            _parking = _repository.GetById(GetIdFromList()) as ParkingGameModel;
        }


        private void StartScenarios()
        {
            new ScenariosBuilder(_sceneActions).BusLeavesFromParking()
                .BusArrivesToParking()
                .Build();

            new ScenariosBuilder(_sceneActions).BusArrivesToParking().Build();

            new ScenariosBuilder(_sceneActions).BusArrivesToParking().Build();

            new ScenariosBuilder(_sceneActions).BusLeavesFromParking().Build();
        }
    }
}
