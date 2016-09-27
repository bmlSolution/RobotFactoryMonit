using BotFactory.Common.Interface;
using BotFactory.Common.Tools;
using BotFactory.Reporting;
using System;
using System.Threading.Tasks;

namespace BotFactory.Models
{
    public abstract class BaseUnit : ReportingUnit, IBaseUnit
    {
        public double Speed { set; get; } = 1;
        private Coordinates _coor;

        public Coordinates CurrentPos
        {
            get
            {
                if (_coor == null)
                {
                    _coor = new Coordinates();
                }
                return _coor;
            }
            set
            {
                _coor = value;
            }

        }

        public string Name  { set;  get;  }

        public BaseUnit()
        {
            Name = "";
            Speed = 1;
            CurrentPos = new Coordinates();
        }

        public BaseUnit(string name, double speed = 1)
        {
            Name = name;
            Speed = speed;
            CurrentPos = new Coordinates();

        }


        public async Task<Boolean> Move(Coordinates newcoor)
        {
            if(!_coor.Equals(newcoor))
            {
                Vector deplacement = Vector.FromCoordinates(_coor, newcoor);
                await Task.Delay(System.TimeSpan.FromMilliseconds(deplacement.Length()* Speed*100));

                _coor = newcoor;
            }
            return true;
        }
    }
}
