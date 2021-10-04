using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusSimulation.Services.Test;
using BusSimulation.ViewModels;
using Simulation.CommandsManagement;

namespace BusSimulation.Commands
{
    public class AsyncCommandExample : AsyncCommandBase
    {
        private readonly ExampleViewModel _exampleViewModel;
        private readonly IAsyncServiceExample _asyncServiceExample;

        public AsyncCommandExample(ExampleViewModel exampleViewModel, 
                                    IAsyncServiceExample asyncServiceExample,
                                    Action<Exception> onException) : base(onException)
        {
            _exampleViewModel = exampleViewModel;
            _asyncServiceExample = asyncServiceExample;
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            _exampleViewModel.StatusMessage = "doing smthng";
            await _asyncServiceExample.DoSomething(_exampleViewModel.Name);
            _exampleViewModel.StatusMessage = "successfully done!";
        }
    }
}
