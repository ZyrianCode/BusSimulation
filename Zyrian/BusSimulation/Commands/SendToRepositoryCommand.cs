using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BusSimulation.Models;
using Simulation.CommandsManagement;
using Simulation.Data.Repositories.Abstract;
using Simulation.Data.Services;
using Simulation.Data.Services.Abstract;


namespace BusSimulation.Commands
{
    public class SendToRepositoryCommand : Command
    {

        public override bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public override void Execute(object parameter)
        {
            
        }

        public void SetData(ParkingWpfModel parkingWpfModel, IParkingRepositoryProvider parkingRepository)
        {
            IParkingServiceProvider service = new ParkingService(parkingRepository);
            service.AddParking(parkingWpfModel);
        }
    }
}
