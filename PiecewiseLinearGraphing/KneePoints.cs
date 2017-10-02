using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiecewiseLinearGraphing
{
    public class KneePoints
    {
        private Point _leftKneePoint;
        private Point _rightKneePoint;
        private Point _max_XY;

        public Point LeftKneePoint => _leftKneePoint;
        public Point RightKneePoint => _rightKneePoint;
        public Point Max_XY => _max_XY;
        public decimal A0 => LeftKneePoint.Y / LeftKneePoint.X;
        public decimal A1 => (RightKneePoint.Y - LeftKneePoint.Y) / (RightKneePoint.X - LeftKneePoint.X);
        public decimal A2 => (Max_XY.Y - RightKneePoint.Y) / (Max_XY.X - RightKneePoint.X);

        public static bool ValidKneePoints(Point leftKneePoint, Point rightKneePoint, Point Max_XY)
        {
            if (leftKneePoint.X == 0 || rightKneePoint.X - leftKneePoint.X == 0 || Max_XY.X - rightKneePoint.X == 0)
                return false; // Avoid divide-by-zero errors

            decimal a0 = leftKneePoint.Y / leftKneePoint.X;
            decimal a1 = (rightKneePoint.Y - leftKneePoint.Y) / (rightKneePoint.X - leftKneePoint.X);
            decimal a2 = (Max_XY.Y - rightKneePoint.Y) / (Max_XY.X - rightKneePoint.X);

            return (a0 < a1 && a1 < a2);
        }

        public static bool ValidKneePoints(KneePoints kneePoints, Point max_XY)
        {
            return ValidKneePoints(kneePoints.LeftKneePoint, kneePoints.RightKneePoint, max_XY);
        }

        public bool SetKneePoints(Point leftKneePoint, Point rightKneePoint, Point max_XY)
        {
            if (ValidKneePoints(leftKneePoint, rightKneePoint, max_XY))
            {
                _leftKneePoint = leftKneePoint;
                _rightKneePoint = rightKneePoint;
                _max_XY = max_XY;
                return true;
            }
            return false;
        }
    }

    public class InvalidKneePointException : Exception
    {
    }
}
