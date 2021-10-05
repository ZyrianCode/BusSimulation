using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BusSimulation.Commands;
using Simulation.Infrastructure.ViewModelAbstractComponents;

namespace BusSimulation.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel = new BusCreationViewModel();

        public string ModelViewName { get; set; }

        public BaseViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set => Set(ref _selectedViewModel, value);
        }

        public ICommand SetViewModelCommand { get; set; }

        public MainViewModel()
        {
            SetViewModelCommand = new SetViewModelCommand(this);
        }
    }
}
