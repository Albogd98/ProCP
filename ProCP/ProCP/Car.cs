using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP
{
    public class Car : TrafficMember
    {
        private int speed;
        private int acceleration;
        private int positionX;
        private int prev_positionx;
        private int positionY;
        private int prev_positiony;
        private double netDistance;
        private bool breaks;
        private string ffvar;

        public int Speed
        {
            get => default(int);
            set
            {
            }
        }

        public int PositionX { get { return positionX; } set { positionX = value; } }
        public int PositionY { get { return positionY; } set { positionY = value; } }
        public string fFVar { get { return ffvar; } set { ffvar = value; } }

        public Car(int s, int a, int px, int py)
        {
            speed = s;
            acceleration = a;
            positionX = px;
            positionY = py;
            breaks = false;
        }

        public void Break()
        {
            speed = 0;
            breaks = true;
        }

        public void Accelerate()
        {
            while (speed < acceleration)
            {
                speed++;
            }
        }

        public void calcNetDistance()
        {
            // Net Distance formula -- S = X1 - X - L1
            // L1 = vehicle length
            // X1 = leading vehicle
        }

        public void MoveForward()
        {
            switch (ffvar)
            {
                case "Left":
                    positionX--;
                    break;
                case "Right":
                    positionX++;
                    break;
                case "Up":
                    positionY++;
                    break;
                case "Down":
                    positionY--;
                    break;
            }
        }

        public void TurnLeft()
        {
            switch (ffvar)
            {
                case "Left":
                    positionX--;
                    positionY--;
                    break;
                case "Right":
                    positionX++;
                    positionY++;
                    break;
                case "Up":
                    positionX--;
                    positionY++;
                    break;
                case "Down":
                    positionX++;
                    positionY--;
                    break;
            }
        }

        public void TurnRight()
        {
            switch (ffvar)
            {
                case "Left":
                    positionX++;
                    break;
                case "Right":
                    positionX--;
                    break;
                case "Up":
                    positionY--;
                    break;
                case "Down":
                    positionY++;
                    break;
            }
        }

        public void U_Turn()
        {
            switch (ffvar)
            {
                case "Left":
                    positionX++;
                    break;
                case "Right":
                    positionX--;
                    break;
                case "Up":
                    positionY--;
                    break;
                case "Down":
                    positionY++;
                    break;
            }
        }

        public void facingForward()
        {
            if (!breaks)
            {
                if (positionX < prev_positionx)
                {
                    ffvar = "Left";
                }
                else if (positionX > prev_positionx)
                {
                    ffvar = "Right";
                }
                else if (positionY < prev_positiony)
                {
                    ffvar = "Down";
                }
                else
                    ffvar = "Up";
            }
        }
    }
}
