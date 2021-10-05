using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Simulation.Infrastructure.ViewModelAbstractComponents;
using Simulation.Windows;

namespace BusSimulation.ViewModels
{
    public class BusViewModel : BaseViewModel
    {
        private string _busNumber;

        [Required][StringLength(6, MinimumLength = 6)] public string BusNumber
        {
            get => _busNumber; 
            set => Set(ref _busNumber, value);
        }

        public override string OnValidate(string propertyName)
        {
            if (_busNumber == null)
            {
                return "Number can't be null!";
            }
            return base.OnValidate(propertyName);
        }
    }
}
