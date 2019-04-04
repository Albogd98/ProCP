using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProCP
{
    public class Car
    {
        private int _speed;
        private int _acceleration;
        private Position _current;
        private double _netDistance;
        private int _length;
        private bool _brakes;

        public int _Speed { get { return _speed; } }
        

        public int PositionX { get { return _current.X; } set { _current.X = value; } }
        public int PositionY { get { return _current.Y; } set { _current.Y = value; } }

        public Car(int s, int a, int px, int py, int l)
        {
            this._speed = s;
            this._acceleration = a;
            this._current.X = px;
            this._current.Y = py;
            this._brakes = false;
        }

        public void Break()
        {
            _speed -= 5;
            _brakes = true;
        }

        public void Accelerate()
        {

            while (_speed < _acceleration)
            {
                _speed++;
            }
        }

        public double calcNetDistance(Car c)
        {
            // Net Distance formula -- S = X1 - X - L1
            // L1 = vehicle length
            // X1 = leading vehicle

            int[] _positionX1 = new int[] { PositionX, PositionY };
            int[] _positionX2 = new int[] { c.PositionX, c.PositionY };
            _netDistance = Math.Sqrt(Math.Pow(_positionX2[0] - _positionX1[0], 2) + Math.Pow(_positionX1[1] - _positionX2[1], 2));

            return _netDistance;
        }

        public bool startBraking()
        {


            return true;
        }

        public void MoveForward()
        {
            
        }

        public void TurnLeft()
        {
           
        }

        public void TurnRight()
        {
            
        }

        public void U_Turn()
        {
            
        }
    }
}
