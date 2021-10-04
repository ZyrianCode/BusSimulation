using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.Models.WPF;
using Simulation.Windows;

namespace BusSimulation.ViewModels
{
    public class ParkingViewModel : BaseViewModel
    {
        public override string ViewModelName => "ParkingViewModel";
        private ParkingWpfModel _parking;

        public ParkingViewModel()
        {
            _parking = new();
        }
        
    }
}
