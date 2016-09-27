namespace BotFactory.Models
{
    public class HAL: WorkingUnit
    {
        public HAL()
        {
            Speed = 0.5;
            BuildTime = 7;
        }
        public override string Process()
        {
            return "Je gère le Discovery One";
        }
    }
}
