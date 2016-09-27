using BotFactory.Common.Interface;
using System;

namespace BotFactory.Reporting
{
    public class ReportingFactory
    {
        public virtual event EventHandler FactoryProgress;
        public void OnStatusChanged(IStatusChangedEventArgs newStatuts)
        {
            FactoryProgress?.Invoke(this, (StatusChangedEventArgs)newStatuts);
        }
    }
}
