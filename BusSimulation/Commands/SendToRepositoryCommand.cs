using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.CommandsManagement;
using Simulation.Data.Repositories.Abstract;
using Simulation.Data.Services;
using Simulation.Data.Services.Abstract;
using Simulation.Models.WPF;

namespace BusSimulation.Commands
{
    public class SendToRepositoryCommand : Command
    {
        private readonly ParkingWpfModel _parkingWpfModel;
        private readonly IParkingRepositoryProvider _parkingRepository;

        public SendToRepositoryCommand(ParkingWpfModel parkingWpfModel, IParkingRepositoryProvider parkingRepository)
        {
            _parkingWpfModel = parkingWpfModel;
            _parkingRepository = parkingRepository;
        }

        public override bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public override void Execute(object parameter)
        {
            IParkingServiceProvider service = new ParkingService(_parkingRepository);
            service.AddParking(_parkingWpfModel);
        }
    }
}
