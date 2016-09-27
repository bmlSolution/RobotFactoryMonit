using System;

namespace BotFactory.Common.Interface
{
    public interface IReportingUnit
    {
        event EventHandler UnitStatusChanged;
        void OnStatusChanged(IStatusChangedEventArgs e);
    }

    public interface IStatusChangedEventArgs 
    {
        string NewStatus { get; set; }
    }
}
