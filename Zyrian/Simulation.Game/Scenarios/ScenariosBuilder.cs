namespace Simulation.Game.Scenarios
{
    public class ScenariosBuilder
    {
        private readonly SceneActions _sceneActions;
        private readonly Scenario _scenario;
        public ScenariosBuilder(SceneActions sceneActions)
        {
            _scenario = new();
            _sceneActions = sceneActions;
        }

        public ScenariosBuilder BusArrivesToParking()
        { 
            _sceneActions.BusArrivesToParkingAction();
            return this;
        }

        public ScenariosBuilder BusLeavesFromParking()
        {
            _sceneActions.BusLeavesParkingAction();
            return this;
        }

        public Scenario Build() => _scenario;
    }
}
