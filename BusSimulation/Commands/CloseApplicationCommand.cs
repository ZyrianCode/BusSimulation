using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using CommandsManagement;

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
