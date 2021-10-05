using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Simulation.Data.Repositories;
using Simulation.Data.Repositories.Abstract;
using Simulation.Data.Services;
using Simulation.Domain.Models;

namespace BusSimulation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static IRepository repository = new Repository();
        TestService<Bus> testService = new(repository);
    }
}
