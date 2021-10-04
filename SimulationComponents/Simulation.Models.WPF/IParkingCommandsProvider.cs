namespace Simulation.Models.WPF
{
    interface IParkingCommandsProvider
    {
        public void AddBusToParking(BusWpfModel bus);
        public void RemoveBusFromParking(BusWpfModel bus);
        public BusWpfModel FindBus(BusWpfModel bus);
    }
}
