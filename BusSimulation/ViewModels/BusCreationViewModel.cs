using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows;
using Models.WPF;

namespace BusSimulation.ViewModels
{
    public class BusCreationViewModel : BaseViewModel
    {
        public override string ViewModelName => "BusCreationViewModel";
        public ObservableCollection<BusWpfModel> Buses;

        public BusCreationViewModel()
        {
            
        }
    }
}
