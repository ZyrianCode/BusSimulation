using System.Windows;
using BusSimulation.ViewModels;
using Simulation.Data.Repositories.Services.Abstract;
using Simulation.Domain.Models.Abstract;
using Simulation.Game;

namespace BusSimulation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
