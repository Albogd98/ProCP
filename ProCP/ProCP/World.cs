using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProCP
{
    public class World
    {
        List<Car> _cars = new List<Car>();
        List<Road> _roads = new List<Road>();

        public World()
        {
            
        }

        public void addCar(Car ob)
        {
            _cars.Add(ob);
        }

        public void rmCar(Car ob)
        {
            _cars.Remove(ob);
        }

        public void checkCar(Car myCar)
        {
            foreach(Car c in _cars)
            {
                if (c.PositionX == myCar.PositionX || c.PositionY == myCar.PositionY)
                {
                    myCar.calcNetDistance(c);
                }
            }
        }
    }
}