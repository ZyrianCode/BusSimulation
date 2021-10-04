using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows;

namespace BusSimulation.ViewModels
{
    public class BusViewModel : BaseViewModel
    {
        private string _BusNumber;

        [Required][StringLength(6, MinimumLength = 6)] public string BusNumber
        {
            get => _BusNumber; 
            set => Set(ref _BusNumber, value);
        }

        public override string OnValidate(string propertyName)
        {
            if (_BusNumber == null)
            {
                return "Number can't be null!";
            }
            return base.OnValidate(propertyName);
        }
    }
}
