using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandsManagement;
using Data.Abstract;
using Data.Services;
using Data.Services.Abstract;
using Models.WPF;

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
