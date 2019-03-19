using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProCP
{
    public class Intersection : Road
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

            MPIN1X = CenterX + lengthSmallSqSide;
            MPIN1Y = CenterY + quarter;
            MPOUT1X = CenterX + quarter;
            MPOUT1Y = CenterY + lengthSmallSqSide;

            MPIN2X = CenterX - quarter;
            MPIN2Y = CenterY + lengthSmallSqSide;
            MPOUT2X = CenterX - lengthSmallSqSide;
            MPOUT2Y = CenterY + quarter;

            MPIN3X = CenterX - lengthSmallSqSide;
            MPIN3Y = CenterY - quarter;
            MPOUT3X = CenterX - quarter;
            MPOUT3Y = CenterY - lengthSmallSqSide;

            MPIN4X = CenterX + quarter;
            MPIN4Y = CenterY - lengthSmallSqSide;
            MPOUT4X = CenterX + lengthSmallSqSide;
            MPOUT4Y = CenterY - quarter;
        }

        //Turn right -> same square out
        //Turn left -> if 1/2 then +2 index out or if 3/4 then -2 index out
        //Go straight -> +1 index out
        //U-turn -> -1 index out
    }
}