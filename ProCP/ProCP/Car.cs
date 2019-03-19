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
        private Position _previous;
        private double _netDistance;
        private bool _breaks;

        public int Speed
        {
            get => default(int);
            set
            {
            }
        }

        public int PositionX { get { return _current.X; } set { _current.X = value; } }
        public int PositionY { get { return _current.Y; } set { _current.Y = value; } }

        public Car(int s, int a, int px, int py)
        {
            _speed = s;
            _acceleration = a;
            _current.X = px;
            _current.Y = py;
            _breaks = false;
        }

        public void Break()
        {
            _speed = 0;
            _breaks = true;
        }

        public void Accelerate()
        {
            while (_speed < _acceleration)
            {
                _speed++;
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
            switch (_facingForward)
            {
                case "Left":
                    _current.X--;
                    break;
                case "Right":
                    _current.X++;
                    break;
                case "Up":
                    _current.Y++;
                    break;
                case "Down":
                    _current.Y--;
                    break;
            }
        }

        public void TurnLeft()
        {
            switch (_facingForward)
            {
                case "Left":
                    _current.X--;
                    _current.Y--;
                    break;
                case "Right":
                    _current.X++;
                    _current.Y++;
                    break;
                case "Up":
                    _current.X--;
                    _current.Y++;
                    break;
                case "Down":
                    _current.X++;
                    _current.Y--;
                    break;
            }
        }

        public void TurnRight()
        {
            switch (_facingForward)
            {
                case "Left":
                    _current.X++;
                    break;
                case "Right":
                    _current.X--;
                    break;
                case "Up":
                    _current.Y--;
                    break;
                case "Down":
                    _current.Y++;
                    break;
            }
        }

        public void U_Turn()
        {
            switch (_facingForward)
            {
                case "Left":
                    _current.X++;
                    break;
                case "Right":
                    _current.X--;
                    break;
                case "Up":
                    _current.Y--;
                    break;
                case "Down":
                    _current.Y++;
                    break;
            }
        }
    }
}
