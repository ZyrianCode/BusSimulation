using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandsManagement
{
    /// <summary>
    /// Асинхронная команда
    /// </summary>
    public abstract class AsyncCommandBase : ICommand
    {
        private readonly Action<Exception> _onException;

        private bool _isExecuting;

        private bool IsExecuting
        {
            get => _isExecuting;
            set
            {
                _isExecuting = value;
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
        }

        public AsyncCommandBase(Action<Exception> onException)
        {
            _onException = onException;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) => !IsExecuting;

        /// <summary>
        /// Метод, обеспечивающий асинхронное выполнение
        /// </summary>
        /// <param name="parameter"></param>
        public async void Execute(object parameter)
        {
            IsExecuting = true;

            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception ex){ _onException?.Invoke(ex);}

            IsExecuting = false;
        }

        /// <summary>
        /// Метод асинхронного выполнения
        /// </summary>
        /// <param name="parameter"></param>
        protected abstract Task ExecuteAsync(object parameter);
    }
}
