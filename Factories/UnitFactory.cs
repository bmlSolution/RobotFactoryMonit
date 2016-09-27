using BotFactory.Common.Interface;
using BotFactory.Common.Tools;
using BotFactory.Models;
using BotFactory.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BotFactory.Factories
{
    public class UnitFactory: ReportingFactory , IUnitFactory
    {
        private List<IFactoryQueueElement> _queue;
        private List<ITestingUnit> _storage;

        private int _QueueCapacity { get; set; }
        private int _StorageCapacity { get; set; }
        public int QueueCapacity
        {
            get { return _QueueCapacity; }
            set { _QueueCapacity = value; }
        }

        public int StorageCapacity
        {
            get { return _StorageCapacity; }
            set { _StorageCapacity = value; }
        }
        public List<IFactoryQueueElement> Queue
        {
            get { return _queue.ToList(); }
            set { _queue = value; }
        }
        public List<ITestingUnit> Storage
        {
            get { return _storage.ToList(); }
            set { _storage = value; }
        }

        public int QueueFreeSlots
        {
            get { return QueueCapacity - Queue.Count; }
        }
        public int StorageFreeSlots
        {
            get { return StorageCapacity - _storage.Count; }
        }
        public string Model { get; set; }
        public TimeSpan QueueTime { get; set; }
        private Task WorkInProgress;
        public UnitFactory(int longueurQueue, int capaEntrepot)
        {
            QueueCapacity = longueurQueue;
            StorageCapacity = capaEntrepot;
            Queue = new List<IFactoryQueueElement>();
            Storage = new List<ITestingUnit>();
        }

        //Fonction pour l'ajout d'un robot à la chaîne de montage
        public bool AddWorkableUnitToQueue(Type bot, string name, Coordinates parkStation, Coordinates workStation )
        {
            //On vérifie si la queue peut accueillir un nouvel élément et qu'il pourrat être stocké.
            bool state = Queue.Count + 1 > QueueCapacity || Queue.Count + Storage.Count + 1 > StorageCapacity ? false : true;
            if (state)
            {
                _queue.Add(new FactoryQueueElement(name, bot, parkStation, workStation));
                LaunchWork();
            }
            return state;
        }
        public void LaunchWork()//Méthode pour la gestion de la "tâche de fond".
        {
            if(WorkInProgress == null )//La tâche n'existe pas.
            {
                WorkInProgress = BuildingRobot();
            }
            else if(WorkInProgress.IsCompleted)//La tâche c'est terminé.
            {
                WorkInProgress.Dispose();
                WorkInProgress = null;
                WorkInProgress = BuildingRobot();
            }
        }
        private async Task BuildingRobot()//Méthode asynchrone représentant la chaîne de montage.
        {
            try
            {
                await Task.Run(() =>
                {
                    while (Queue.Count > 0)//Subsistance de la tâche tant que la queue n'est pas vide.
                    {
                            IFactoryQueueElement botToBuild = Queue.First();
                            ITestingUnit botToTest = (ITestingUnit)Activator.CreateInstance(botToBuild.Model);
                            botToTest.Model = botToBuild.Model.Name;
                            botToTest.Name = botToBuild.Name;
                            botToTest.WorkingPos = botToBuild.WorkingPos;
                            botToTest.ParkingPos = botToBuild.ParkingPos;
                            WorkingUnit bot = (WorkingUnit)Activator.CreateInstance(botToBuild.Model);
                            OnStatusChanged(new StatusChangedEventArgs() { NewStatus = botToBuild.Name +" start to build.", QueueElement = botToBuild });
                            Task.Delay(Convert.ToInt32(TimeSpan.FromSeconds(bot.BuildTime).TotalMilliseconds)).Wait();
                            QueueTime = QueueTime + TimeSpan.FromSeconds(bot.BuildTime);

                            _queue.Remove(botToBuild);
                            
                            OnStatusChanged(new StatusChangedEventArgs() { NewStatus = botToBuild.Name + " is ready to tests.", TestingUnit = botToTest });

                            _storage.Add(botToTest);
                    }
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR : ---Factory working stopped---\n\r"+ex.Message);
            }
        }
    }
}
