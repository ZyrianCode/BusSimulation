using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusSimulation.Services.Test
{
    public class AsyncServiceExample : IAsyncServiceExample
    {
        public async Task DoSomething(string something)
        {
            await Task.Delay(1000);
        }
    }
}
