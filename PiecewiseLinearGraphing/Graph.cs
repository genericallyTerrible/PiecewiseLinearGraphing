using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PiecewiseLinearGraphing
{
    public class Graph
    {
        protected List<Exposure> _exposures = new List<Exposure>();
        protected KneePoints _kneePoints = new KneePoints();
        protected Point _max_XY;

        public IList<Exposure> Exposures => _exposures.AsReadOnly();
        public KneePoints KneePoints => _kneePoints;
        public Point Max_XY => _max_XY;


        public event EventHandler KneePointsChanged;
        public delegate void KneePointsChangedHandler(object sender, KneePointsChangedEventArgs e);

        protected virtual void OnKneePointsChanged(object sender, KneePointsChangedEventArgs e)
        {
            EventHandler handler = KneePointsChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public bool SetupGraph(Point leftKneePoint, Point rightKneePoint, Point max_XY)
        {
            if (KneePoints.ValidKneePoints(leftKneePoint, rightKneePoint, max_XY))
            {
                _kneePoints.SetKneePoints(leftKneePoint, rightKneePoint, max_XY);
                _max_XY = max_XY;
                OnKneePointsChanged(this, new KneePointsChangedEventArgs(_kneePoints, max_XY));
                return true;
            }
            return false;
        }

        public bool SetupGraph(KneePoints kneePoints, Point max_XY)
        {
            return SetupGraph(kneePoints.LeftKneePoint, kneePoints.RightKneePoint, max_XY);
        }

        public void ClearExposures()
        {
            if (_exposures.Count > 0)
            {
                foreach (Exposure exp in _exposures)
                {
                    KneePointsChanged -= exp.KneePointsChangedEventHandler;
                }
                _exposures.Clear();
            }
        }

        public static double DegreesToRadians(double degrees)
        {
            return degrees * (Math.PI / 180);
        }

        public static double RadiansToDegrees(double radians)
        {
            return radians * (180 / Math.PI);
        }
    }

    public class SingleExposureGraph : Graph
    {
        public bool AddExposure(decimal slope)
        {
            if (_exposures.Count == 0)
            {
                Exposure newExposure = new Exposure(slope, _kneePoints, _max_XY);
                _exposures.Add(newExposure);
                KneePointsChanged += newExposure.KneePointsChangedEventHandler;
                return true;
            }
            return false;
        }
    }

    public class MultipleExposureGraph : Graph
    {
        public void AddExposure(decimal slope)
        {
            Exposure newExposure = new Exposure(slope, _kneePoints, _max_XY);
            _exposures.Add(newExposure);
            KneePointsChanged += newExposure.KneePointsChangedEventHandler;
        }

        public bool RemoveExposure(Exposure exposure)
        {
            if (_exposures.Contains(exposure))
            {
                _exposures.Remove(exposure);
                KneePointsChanged -= exposure.KneePointsChangedEventHandler;
                return true;
            }
            return false;
        }

        public void SetMultipleExposures(decimal startVal, decimal incrementVal, decimal stopVal)
        {
            for (decimal i = startVal; (i <= stopVal) && (((i-startVal) / incrementVal) + 1 < 50); i += incrementVal)
            {
                if (_kneePoints.A0 < i && i < _kneePoints.A0 + incrementVal)
                {
                    AddExposure(_kneePoints.A0);
                }
                if (_kneePoints.A1 < i && i < _kneePoints.A1 + incrementVal)
                {
                    AddExposure(_kneePoints.A1);
                }
                if (_kneePoints.A2 < i && i < _kneePoints.A2 + incrementVal)
                {
                    AddExposure(_kneePoints.A2);
                }
                AddExposure(i);
            }
        }
    }

    public class KneePointsChangedEventArgs : EventArgs
    {
        private KneePoints _newKneePoints;
        private Point _max_XY;

        public KneePoints NewKneePoints => _newKneePoints;
        public Point Max_XY => _max_XY;

        public KneePointsChangedEventArgs(KneePoints newKneePoints, Point max_XY)
        {
            _newKneePoints = newKneePoints;
            _max_XY = max_XY;
        }
    }
}
