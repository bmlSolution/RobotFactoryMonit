using BotFactory.Common.Tools;
using System.Threading.Tasks;

namespace BotFactory.Common.Interface
{
    public interface IWorkingUnit
    {
        Coordinates ParkingPos { set; get; }
        Coordinates WorkingPos { set; get; }
        bool IsWorking { set; get; }
        string Process();
        Task<bool> WorkBegins();
        Task<bool> WorkEnds();
    }
}
