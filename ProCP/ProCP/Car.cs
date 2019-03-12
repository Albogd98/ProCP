using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP
{
    class Car:TrafficMember
    {
        private int speed;
        private int acceleration;
        private int[] position;
        private int breakingSpeed;

        public int Speed
        {
            get => default(int);
            set
            {
            }
        }

        public Car(int s, int a, int[] ps, int b)
        {
            speed = s;
            acceleration = a;
            position = ps;
            breakingSpeed = b;
        }

        public void Break()
        {
            throw new System.NotImplementedException();
        }

        public void Accelerate()
        {
            throw new System.NotImplementedException();
        }

        public void CheckPosition()
        {
            throw new System.NotImplementedException();
        }

        public void MoveForward()
        {
            throw new System.NotImplementedException();
        }

        public void TurnLeft()
        {
            throw new System.NotImplementedException();
        }

        public void TurnRight()
        {
            throw new System.NotImplementedException();
        }

        public void GoStraight()
        {
            throw new System.NotImplementedException();
        }

        public void U_Turn()
        {
            throw new System.NotImplementedException();
        }
    }
}
