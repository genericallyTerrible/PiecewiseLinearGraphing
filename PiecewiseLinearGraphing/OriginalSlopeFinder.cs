using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiecewiseLinearGraphing
{
    public static class OriginalSlopeFinder
    {
        public static decimal FindOriginalSlope(decimal finalValue, KneePoints kneePoints, Point max_XY)
        {
            if (KneePoints.ValidKneePoints(kneePoints, max_XY))
            {
                decimal a0 = kneePoints.LeftKneePoint.Y / kneePoints.LeftKneePoint.X;
                decimal a1 = (kneePoints.RightKneePoint.Y - kneePoints.LeftKneePoint.Y) / (kneePoints.RightKneePoint.X - kneePoints.LeftKneePoint.X);
                decimal a2 = (max_XY.Y - kneePoints.RightKneePoint.Y) / (max_XY.X - kneePoints.RightKneePoint.X);

                decimal p = a0 * max_XY.X;
                decimal q = (a1 * (max_XY.X - kneePoints.LeftKneePoint.X)) + kneePoints.LeftKneePoint.Y;

                if (finalValue < p)
                {
                    return (finalValue / max_XY.X);
                }
                else if (finalValue < q)
                {
                    return ((finalValue - kneePoints.LeftKneePoint.Y) / (max_XY.X - kneePoints.LeftKneePoint.X));
                }
                else if (finalValue < max_XY.Y)
                {
                    return ((finalValue - kneePoints.RightKneePoint.Y) / (max_XY.X - kneePoints.RightKneePoint.X));
                }
                else
                {
                    return (max_XY.Y / max_XY.X);
                }
            }

            throw new InvalidKneePointException();
        }
    }
}
