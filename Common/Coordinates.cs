namespace BotFactory.Common.Tools
{
    public class Coordinates
    {
        public double x
        {
            set; get;
        }

        public double y
        {
            set; get;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public Coordinates(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public Coordinates()
        {
            x = 0;
            y = 0;
        }


    }
}
