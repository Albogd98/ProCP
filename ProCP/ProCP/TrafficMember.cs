using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProCP
{
    public interface TrafficMember
    {
        int PositionX { get; set; }
        int PositionY { get; set; }
        string fFVar { get; set; }
        void facingForward(Car c);
    }
}