using BotFactory.Common.Interface;

namespace BotFactory.Models
{
    public abstract class BuildableUnit : IBuildableUnit
    {
        public double BuildTime { set; get; }

        public BuildableUnit(double time = 5)
        {
            BuildTime = time;
        }
    }
}
