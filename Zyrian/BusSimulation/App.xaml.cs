using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows;
using BusSimulation.ViewModels;
using Simulation.Data.Repositories.Repositories;
using Simulation.Data.Repositories.Repositories.Abstract;
using Simulation.Data.Repositories.Services;
using Simulation.Data.Repositories.Services.Abstract;
using Simulation.Domain.Models;
using Simulation.Domain.Models.Abstract;
using Simulation.Game;

namespace BusSimulation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly IRepository Repository = new Repository();
        
        private static readonly IRepositoryService<IDomainEntity> RepositoryService =
            new RepositoryService<IDomainEntity>(Repository);

        private static readonly Game Game = new();
        
        protected override void OnStartup(StartupEventArgs e)
        {

            MainWindow = new MainWindow();
            MainWindow.Show();
            //Game.Start();
            base.OnStartup(e);
        }

        public static IRepositoryService<IDomainEntity> GetRepositoryService() => RepositoryService;
        public static Game GetGame() => Game;
    }
}
