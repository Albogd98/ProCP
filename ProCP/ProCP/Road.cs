using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProCP
{
    public class Crossing
    {
        private int ccenterX;
        public int CCenterX { get { return ccenterX; } set { ccenterX = value; } }
        private int ccenterY;
        public int CCenterY { get { return ccenterY; } set { ccenterY = value; } }
        private int length;
        private int width;
        Intersection intSec;

        public Crossing(int cX, int cY)
        {
            CCenterX = ccenterX;
            CCenterY = ccenterY;
        }
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