using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProCP
{
    public class Crossing
    {
        private int length;
        private int width;
        private int centerX;
        private int centerY;
    }

    public class Road
    {
        int centerX;
        public int CenterX { get { return centerX; } set { centerX = value; } }
        int centerY;
        public int CenterY { get { return centerY; } set { centerY = value; } }
        List<Car> lsC = new List<Car>();

        public Road(int cX, int cY)
        {
            centerX = cX;
            centerY = cY;
        }

        public void addCar(Car ob)
        {
            lsC.Add(ob);
        }

        public void rmCar(Car ob)
        {
            lsC.Remove(ob);
        }
    }
}