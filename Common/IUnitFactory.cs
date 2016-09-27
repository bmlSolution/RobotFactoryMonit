using BotFactory.Common.Tools;
using System;
using System.Collections.Generic;

namespace BotFactory.Common.Interface
{
    public interface IUnitFactory
    {
        int QueueCapacity { get; set; }
        int StorageCapacity { get; set; }
        int QueueFreeSlots { get; }
        int StorageFreeSlots { get; }
        string Model { get; set; }
        bool AddWorkableUnitToQueue(Type bot, string name, Coordinates parkStation, Coordinates workStation);
        TimeSpan QueueTime { get; set; }
        List<IFactoryQueueElement> Queue { get; set; }
        List<ITestingUnit> Storage { get; set; }
        event EventHandler FactoryProgress;
    }
}
