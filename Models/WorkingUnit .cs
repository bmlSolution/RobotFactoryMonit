using BotFactory.Common.Interface;
using BotFactory.Common.Tools;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public abstract class WorkingUnit : BaseUnit, ITestingUnit, IWorkingUnit
    {
        public Coordinates ParkingPos { set; get; }
        public Coordinates WorkingPos { set; get; }
        public bool IsWorking { set; get; }
        public Action<object, IStatusChangedEventArgs> UnitStatusChanged { set; get; }
        public string Model { get; set; }
        public virtual async Task<bool> WorkBegins()
        {
            return await Move(WorkingPos);
        }
        public virtual string Process()
        {
            return "J'attend ma programmation.";
        }
        public virtual async Task<bool> WorkEnds()
        {
            return await Move(ParkingPos);
        }
    }
}
