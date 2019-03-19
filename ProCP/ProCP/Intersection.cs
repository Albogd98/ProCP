using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProCP
{
    public class Intersection : Road
    {
        private IntersectionSquare _squareOne;
        private IntersectionSquare _squareTwo;
        private IntersectionSquare _squareThree;
        private IntersectionSquare _squareFour;

        public Intersection(int cX, int cY)
            :base(cX, cY)
        {
            lengthBigSqSide = 20;
            lengthSmallSqSide = lengthBigSqSide / 2;
            GetMidPoints();
        }

        //Turn right -> same square out
        //Turn left -> if 1/2 then +2 index out or if 3/4 then -2 index out
        //Go straight -> +1 index out
        //U-turn -> -1 index out
    }
}