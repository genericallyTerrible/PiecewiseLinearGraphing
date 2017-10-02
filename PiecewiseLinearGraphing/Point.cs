using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiecewiseLinearGraphing
{
    public class Point
    {
        private decimal _x;
        private decimal _y;

        public decimal X => _x;
        public decimal Y => _y;

        public Point(decimal x, decimal y)
        {
            _x = x;
            _y = y;
        }
    }
}
