using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusSimulation.ViewModels;
using Simulation.CommandsManagement;
using Simulation.Windows;

namespace BusSimulation.Commands
{
    public class SetViewModelCommand : Command
    {
        private readonly MainViewModel _viewModel;

        private readonly List<BaseViewModel> _viewModels = new()
        {
            new BusCreationViewModel(),
            new ParkingViewModel(),
            new InRouteViewModel()
        };

        public SetViewModelCommand(MainViewModel newViewModel)
        {
            _viewModel = newViewModel;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            _viewModel.SelectedViewModel = _viewModels.Find(x=> x.ViewModelName.Equals(parameter.ToString()));
        }
    }
}
