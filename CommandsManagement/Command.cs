using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandsManagement
{
    /// <summary>
    /// Команда - сущность, при помощи которой происходит общение между моделью представления и представлением
    /// </summary>
    public abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Метод, предоставляемый интерфейсом ICommand, проверяющий возможно ли выполнение комманды
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public abstract bool CanExecute(object parameter);

        /// <summary>
        /// Метод предоставляемый интерфейсом IComand и обеспечивающий выполнение команды
        /// </summary>
        /// <param name="parameter"></param>
        public abstract void Execute(object parameter);
    }
}
