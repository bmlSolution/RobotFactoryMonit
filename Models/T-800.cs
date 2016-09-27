namespace BotFactory.Models
{
    public class T_800 : WorkingUnit
    {
        public T_800()
        {
            Speed = 3;
            BuildTime = 10;
        }

        public override string Process()
        {
            return "Sarah Connor ?";
        }
    }
}
