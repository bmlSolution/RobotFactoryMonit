using System;


namespace Reporting
{
    public delegate void UnitStatusChanged(object sender, EventArgs e);

    public abstract class ReportingUnit
    {


        public virtual void OnStatusChanged(StatusChangedEventArgs newStatus)
        {
            UnitStatusChanged(this, newStatus);
        }
    }

    public class StatusChangedEventArgs : EventArgs
    {
        string NewStatus;


    }
}

