using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProCP
{
    public class Intersection : Crossing
    {
        private int lengthSmallSqSide;
        private int lengthBigSqSide;
        double MPIN1X, MPIN2X, MPIN3X, MPIN4X;
        double MPIN1Y, MPIN2Y, MPIN3Y, MPIN4Y;
        double MPOUT1X, MPOUT2X, MPOUT3X, MPOUT4X;
        double MPOUT1Y, MPOUT2Y, MPOUT3Y, MPOUT4Y;

        public Intersection(int cX, int cY)
            :base(cX, cY)
        {
            lengthBigSqSide = 20;
            lengthSmallSqSide = lengthBigSqSide / 2;
            GetMidPoints();
        }

        private void GetMidPoints()
        {
            int quarter = lengthBigSqSide / 4;

            MPIN1X = CCenterX + lengthSmallSqSide;
            MPIN1Y = CCenterY + quarter;
            MPOUT1X = CCenterX + quarter;
            MPOUT1Y = CCenterY + lengthSmallSqSide;

            MPIN2X = CCenterX - quarter;
            MPIN2Y = CCenterY + lengthSmallSqSide;
            MPOUT2X = CCenterX - lengthSmallSqSide;
            MPOUT2Y = CCenterY + quarter;

            MPIN3X = CCenterX - lengthSmallSqSide;
            MPIN3Y = CCenterY - quarter;
            MPOUT3X = CCenterX - quarter;
            MPOUT3Y = CCenterY - lengthSmallSqSide;

            MPIN4X = CCenterX + quarter;
            MPIN4Y = CCenterY - lengthSmallSqSide;
            MPOUT4X = CCenterX + lengthSmallSqSide;
            MPOUT4Y = CCenterY - quarter;
        }

        //Turn right -> same square out
        //Turn left -> if 1/2 then +2 index out or if 3/4 then -2 index out
        //Go straight -> +1 index out
        //U-turn -> -1 index out
    }
}