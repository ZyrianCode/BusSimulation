using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BusSimulation.Commands;
using Simulation.Data.Repositories.Services.Abstract;
using Simulation.Domain.Models.Abstract;
using Simulation.Game;
using Simulation.Infrastructure.ViewModelAbstractComponents;

namespace BusSimulation.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;

        public string ModelViewName { get; set; }

        public BaseViewModel SelectedViewModel
        {
            get => _selectedViewModel;
            set => Set(ref _selectedViewModel, value);
        }

        public ICommand SetViewModelCommand { get; set; }


        public MainViewModel()
        {
            _selectedViewModel = new BusCreationViewModel();
            SetViewModelCommand = new SetViewModelCommand(this);
        }
    }
}
