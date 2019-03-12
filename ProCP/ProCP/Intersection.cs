using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProCP
{
    public class Intersection
    {
        private int centerX;
        private int centerY;
        private int lengthSmallSqSide;
        private int lengthBigSqSide;
        double MPIN1X, MPIN2X, MPIN3X, MPIN4X;
        double MPIN1Y, MPIN2Y, MPIN3Y, MPIN4Y;
        double MPOUT1X, MPOUT2X, MPOUT3X, MPOUT4X;
        double MPOUT1Y, MPOUT2Y, MPOUT3Y, MPOUT4Y;

        public Intersection(int x, int y)
        {
            lengthBigSqSide = 20;
            lengthSmallSqSide = lengthBigSqSide / 2;
            GetMidPoints();
        }

        private void GetMidPoints()
        {
            int quarter = lengthBigSqSide / 4;

            MPIN1X = centerX + lengthSmallSqSide;
            MPIN1Y = centerY + quarter;
            MPOUT1X = centerX + quarter;
            MPOUT1Y = centerY + lengthSmallSqSide;

            MPIN2X = centerX - quarter;
            MPIN2Y = centerY + lengthSmallSqSide;
            MPOUT2X = centerX - lengthSmallSqSide;
            MPOUT2Y = centerY + quarter;

            MPIN3X = centerX - lengthSmallSqSide;
            MPIN3Y = centerY - quarter;
            MPOUT3X = centerX - quarter;
            MPOUT3Y = centerY - lengthSmallSqSide;

            MPIN4X = centerX + quarter;
            MPIN4Y = centerY - lengthSmallSqSide;
            MPOUT4X = centerX + lengthSmallSqSide;
            MPOUT4Y = centerY - quarter;

        }
    }
}