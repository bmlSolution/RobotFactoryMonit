using BotFactory.Common.Interface;
using BotFactory.Models;
using System;

namespace BotFactory.Reporting
{

    public abstract class ReportingUnit : BuildableUnit, IReportingUnit
    {

        public event EventHandler UnitStatusChanged;

        public virtual void OnStatusChanged(IStatusChangedEventArgs newStatus)
        {
            UnitStatusChanged?.Invoke(this, (StatusChangedEventArgs)newStatus);
        }
    }

    public class StatusChangedEventArgs : EventArgs , IStatusChangedEventArgs
    {

        public string NewStatus { get; set; }

        public IFactoryQueueElement QueueElement { get; set; }
        public ITestingUnit TestingUnit { get; set; }

    }
}

