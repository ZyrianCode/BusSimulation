using System.Windows;
using Simulation.CommandsManagement;

namespace BusSimulation.Commands
{
    public class CloseApplicationCommand : Command
    {
        public override bool CanExecute(object parameter)
        {
            //Проверить сохранено ли всё
            return true;
        }

        public override void Execute(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
