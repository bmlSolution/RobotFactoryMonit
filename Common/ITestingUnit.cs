using BotFactory.Common.Tools;
using System;
using System.Threading.Tasks;

namespace BotFactory.Common.Interface
{
    public interface ITestingUnit
    {
        string Model { get; set; }
        string Name { set; get; }
        Coordinates CurrentPos { get; set; }
        double Speed { get; set; }
        Task<Boolean> Move(Coordinates newcoor);
        double BuildTime { get; set; }
        void OnStatusChanged(IStatusChangedEventArgs e);
        Coordinates ParkingPos { get; set; }
        Coordinates WorkingPos { get; set; }
        bool IsWorking { get; set; }
        Action<object, IStatusChangedEventArgs> UnitStatusChanged { get; set; }
        Task<bool> WorkBegins();
        Task<bool> WorkEnds();
    }
}
