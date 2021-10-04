using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.Windows;

namespace BusSimulation.ViewModels
{
    public class ExampleViewModel : BaseViewModel
    {
        public override string ViewModelName => "ExampleViewModel";

        private string _name;

        public string Name
        {
            get => _name;
            set => Set(ref _name, value);
        }
        private string _statusMessage;

        public string StatusMessage
        {
            get => _statusMessage;
            set => Set(ref _statusMessage, value);
        }
    }
}
