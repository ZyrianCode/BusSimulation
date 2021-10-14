using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using BusSimulation.Models;
using BusSimulation.WpfMappers;
using Simulation.CommandsManagement;
using Simulation.Data.Repositories.Services.Abstract;
using Simulation.Domain.Models.Abstract;
using Simulation.Game;
using Simulation.Infrastructure.ViewModelAbstractComponents;



namespace BusSimulation.ViewModels
{
    public class BusCreationViewModel : BaseViewModel
    {
        public override string ViewModelName => "BusCreationViewModel";
        public ObservableCollection<ParkingWpfModel> Parking { get; set; }
        public ObservableCollection<BusWpfModel> Buses { get; set; }

        private static IRepositoryService<IDomainEntity> _repositoryService = App.GetRepositoryService();
        private readonly Game _game = App.GetGame();

        public BusCreationViewModel()
        {

            Buses = new ObservableCollection<BusWpfModel>();
            Parking = new ObservableCollection<ParkingWpfModel>();

            #region Commands

                AddParking = new RelayCommand(OnAddedParkingCommandExecuted, CanAddParkingExecuteCommand);
                RemoveParking = new RelayCommand(OnRemovedParkingCommandExecuted, CanRemoveParkingExecuteCommand);
                AddBus = new RelayCommand(OnAddedBusCommandExecuted, CanAddBusExecuteCommand);
                RemoveBus = new RelayCommand(OnRemovedBusCommandExecuted, CanRemoveBusExecuteCommand);

                SendParkingToRepository =
                    new RelayCommand(OnSendedToRepositoryCommandExecuted, CanSendToRepositoryExecuteCommand);

                StartGame = new RelayCommand(OnStartedGameCommandExecuted, CanStartGameExecuteCommand);

                #endregion
        }

        private ParkingWpfModel _selectedParking;

        public ParkingWpfModel SelectedParking
        {
            get => _selectedParking;
            set => Set(ref _selectedParking, value);
        }

        private BusWpfModel _selectedBusWpfModel;

        public BusWpfModel SelectedBus
        {
            get => _selectedBusWpfModel;
            set => Set(ref _selectedBusWpfModel, value);
        }

        #region Commands

            #region AddParkingCommand

                public ICommand AddParking { get; }

                private bool CanAddParkingExecuteCommand(object p) => Buses.Count > 0 && _parkingDescription != null && _parkingName != null;

                private void OnAddedParkingCommandExecuted(object p)
                {
                    var parking = new ParkingWpfModel()
                    {
                        ParkingName = _parkingName,
                        BusStation = Buses,
                        Description = _parkingDescription
                    };

                    Parking.Add(parking);
                }

            #endregion

            #region RemoveParkingCommand

                public ICommand RemoveParking { get; }

                private bool CanRemoveParkingExecuteCommand(object p) => p is ParkingWpfModel parking && Parking.Contains(parking) && Parking.Count > 0;

                private void OnRemovedParkingCommandExecuted(object p)
                {
                    if (p is not ParkingWpfModel parking) return;
                    //var index = Parking
                    //Parking.BusStation.Remove(bus);
                }

            #endregion

            #region AddBus

                public ICommand AddBus { get; }

                private bool CanAddBusExecuteCommand(object p) => true;

                private void OnAddedBusCommandExecuted(object p)
                {
                    var bus = new BusWpfModel()
                    {
                        Number = _busNumber,
                        NumberOfRoute = _routeNumber,
                        ModelName = _modelName,
                        DriverName = _driverName
                    };

                    Buses.Add(bus);
                }

            #endregion

            #region RemoveBus

                public ICommand RemoveBus { get; }

                private bool CanRemoveBusExecuteCommand(object p) => p is BusWpfModel bus && Buses.Contains(bus);

                private void OnRemovedBusCommandExecuted(object p)
                {
                    if (p is not BusWpfModel bus) return;
                    Buses.Remove(bus);
                }

            #endregion

            #region SendParkingToRepository

                public ICommand SendParkingToRepository { get; }

                private bool CanSendToRepositoryExecuteCommand(object p) => Parking.Count > 0;

                private void OnSendedToRepositoryCommandExecuted(object p)
                {
                    foreach (var parkingWpfModel in Parking)
                    {
                        _repositoryService.Add(parkingWpfModel.ToDomainEntity());
                    }
                }

        #endregion

            #region StartGameCommand

                public ICommand StartGame { get; }

                private bool CanStartGameExecuteCommand(object p) => _repositoryService.GetRepositoryItemsCount() > 0;

                private void OnStartedGameCommandExecuted(object p)
                {
                    _game.LinkToRepository(_repositoryService);
                    _game.Start();
                }

            #endregion
        #endregion

        #region BusProperties

        private string _busNumber;
            //[Required]
            //[StringLength(2, MinimumLength = 2)]
            public string BusNumber
            {
                get => _busNumber;
                set => Set(ref _busNumber, value);
            }

            private string _routeNumber;
            //[Required]
           // [StringLength(2, MinimumLength = 2)]
            public string RouteNumber
            {
                get => _routeNumber;
                set => Set(ref _routeNumber, value);
            }

            private string _modelName;
            
            public string ModelName
            {
                get => _modelName;
                set => Set(ref _modelName, value);
            }

            private string _driverName;
            
            public string DriverName
            {
                get => _driverName;
                set => Set(ref _driverName, value);
            }

        #endregion

        #region ParkingProperties

            private string _parkingName;

            public string ParkingName { 
                get => _parkingName; 
                set => Set(ref _parkingName, value);
            }

            private string _parkingDescription;

            public string ParkingDescription { 
                get => _parkingDescription; 
                set => Set(ref _parkingDescription, value);
            }

            
        #endregion

        public override string OnValidate(string propertyName)
        {
            if ((_busNumber == null) || (_driverName == null) 
            || (_modelName == null) || (_routeNumber == null))
            {
                return "Number can't be null!";
            }
            return base.OnValidate(propertyName);
        }
    }
}
