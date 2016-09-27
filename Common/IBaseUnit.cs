using BotFactory.Common.Tools;
using System;
using System.Threading.Tasks;

namespace BotFactory.Common.Interface
{
    public interface IBaseUnit
    {
        double Speed { set; get; }
        Coordinates CurrentPos { get; }

        string Name { set; get; }

        Task<Boolean> Move(Coordinates newcoor);
    }
}
