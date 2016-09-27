namespace BotFactory.Models
{
    public class R2D2 : WorkingUnit
    {
        public R2D2()
        {
            Speed = 1.5;
            BuildTime = 5.5;
        }

        public override string Process()
        {
            return "BIP BIP";
        }
    }
}
