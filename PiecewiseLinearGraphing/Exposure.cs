using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiecewiseLinearGraphing
{
    public class Exposure
    {
        private decimal _slope;
        private List<Point> _dataPoints;
        private KneePoints _kneePoints;
        private Point _max_XY;

        public decimal Slope
        {
            get => _slope;
            set
            {
                _slope = value;
                if (KneePoints.ValidKneePoints(_kneePoints, _max_XY))
                {
                    GenerateDataPoints();
                }
            }
        }
        public IList<Point> DataPoints => _dataPoints.AsReadOnly();
        public KneePoints KneePoints => _kneePoints;
        public Point Max_XY => _max_XY;
        public decimal Final_Y => _dataPoints[_dataPoints.Count - 1].Y;


        public Exposure(decimal slope, KneePoints kneePoints, Point max_XY)
        {
            if (KneePoints.ValidKneePoints(kneePoints.LeftKneePoint, kneePoints.RightKneePoint, max_XY))
            {
                _kneePoints = kneePoints;
            }
            else
            {
                throw new InvalidKneePointException();
            }
            _slope = slope;
            _max_XY = max_XY;
            GenerateDataPoints();
        }

        public void GenerateDataPoints()
        {
            _dataPoints = new List<Point>
            {
                new Point(0, 0) //Reset and add the origin every time
            };

            decimal a0 = _kneePoints.LeftKneePoint.Y / _kneePoints.LeftKneePoint.X;
            decimal a1 = (_kneePoints.RightKneePoint.Y - _kneePoints.LeftKneePoint.Y) / (_kneePoints.RightKneePoint.X - _kneePoints.LeftKneePoint.X);
            decimal a2 = (_max_XY.Y - _kneePoints.RightKneePoint.Y) / (_max_XY.X - _kneePoints.RightKneePoint.X);

            if (_slope < a0)
            {
                _dataPoints.Add(new Point(_max_XY.X, _slope));
            }
            else
            {
                decimal phaseOneSaturation = _kneePoints.LeftKneePoint.Y / _slope;
                _dataPoints.Add(new Point(phaseOneSaturation, _kneePoints.LeftKneePoint.Y));
                _dataPoints.Add(new Point(_kneePoints.LeftKneePoint.X, _kneePoints.LeftKneePoint.Y));

                if (_slope < a1)
                {
                    decimal finalSaturationVal = (_slope * (_max_XY.X - _kneePoints.LeftKneePoint.X)) + _kneePoints.LeftKneePoint.Y;
                    _dataPoints.Add(new Point(_max_XY.X, finalSaturationVal));
                }
                else
                {
                    decimal phaseTwoSaturation = ((_kneePoints.RightKneePoint.Y - _kneePoints.LeftKneePoint.Y) / _slope) + _kneePoints.LeftKneePoint.X;
                    _dataPoints.Add(new Point(phaseTwoSaturation, _kneePoints.RightKneePoint.Y));
                    _dataPoints.Add(new Point(_kneePoints.RightKneePoint.X, _kneePoints.RightKneePoint.Y));

                    if (_slope < a2)
                    {
                        decimal finalSaturationVal = (_slope * (_max_XY.X - _kneePoints.RightKneePoint.X)) + _kneePoints.RightKneePoint.Y;
                        _dataPoints.Add(new Point(_max_XY.X, finalSaturationVal));
                    }
                    else
                    {
                        decimal phaseThreeSaturation = ((_max_XY.Y - _kneePoints.RightKneePoint.Y) / _slope) + _kneePoints.RightKneePoint.X;
                        _dataPoints.Add(new Point(phaseThreeSaturation, _max_XY.Y));
                        _dataPoints.Add(new Point(_max_XY.X, _max_XY.Y));
                    }
                }
            }
        }

        public void KneePointsChangedEventHandler(object sender, EventArgs e)
        {
            KneePointsChangedEventArgs k = (KneePointsChangedEventArgs)e;

            if (KneePoints.ValidKneePoints(k.NewKneePoints, k.Max_XY))
            {
                _kneePoints = k.NewKneePoints;
                _max_XY = k.Max_XY;
                GenerateDataPoints();
            }
        }

    }
}
