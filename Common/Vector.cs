using BotFactory.Common.Interface;
using System;

namespace BotFactory.Common.Tools
{

    public class Vector : IVector
    {
        public double X { set; get; }

        public double Y { set; get; }

        private Vector(double initX, double initY )
        {
            X = initX;
            Y = initY;
        }

        public static Vector FromCoordinates(Coordinates begin, Coordinates end)
        {
            return new Vector(begin.x - end.x, begin.y - end.y); 
        }

        public double Length()
        {
            return Math.Sqrt(Math.Pow(X, 2) * Math.Pow(Y, 2));
        }
    }
}
