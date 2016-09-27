namespace BotFactory.Models
{
    public class Wall_E : WorkingUnit
    {
        public Wall_E()
        {
            Speed = 2;
            BuildTime = 4;
        }

        public override string Process()
        {
            return "Evvveeeeeee....";
        }
    }
}
