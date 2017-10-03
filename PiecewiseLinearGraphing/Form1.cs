using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace PiecewiseLinearGraphing
{
    public partial class PiecewiseForm : Form
    {
        private Graph graph;
        public Graph Graph => graph;
        public Exposure exposure;

        public PiecewiseForm()
        {
            InitializeComponent();
            Point max_XY = new Point(100, 100);
            Point leftKneePoint = new Point(((decimal)0.7 * max_XY.X), ((decimal)1 / 3) * max_XY.Y);
            Point rightKneePoint = new Point(((decimal)0.9 * max_XY.X), ((decimal)2 / 3) * max_XY.Y);

            if (KneePoints.ValidKneePoints(leftKneePoint, rightKneePoint, max_XY))
            {
                MultipleExposureGraph newGraph = new MultipleExposureGraph();
                if (newGraph.SetupGraph(leftKneePoint, rightKneePoint, max_XY))
                {
                    newGraph.SetMultipleExposures();

                    graph = newGraph;
                }

            }
            UpdateChart(graph);
        }

        public void UpdateChart(Graph newGraph)
        {
            foreach (Exposure exp in graph.Exposures)
            {
                exp.GenerateDataPoints();
            }

            PiecewiseGraph.ChartAreas.Clear();
            PiecewiseGraph.Series.Clear();

            // Setup X & Y axis
            PiecewiseGraph.ChartAreas.Add(new ChartArea()
            {
                AxisX = new Axis()
                {
                    Minimum = 0,
                    Maximum = (double)newGraph.Max_XY.X,
                    Interval = (double)(newGraph.Max_XY.X)
                },
                AxisY = new Axis()
                {
                    Minimum = 0,
                    Maximum = (double)newGraph.Max_XY.Y,
                    Interval = (double)(newGraph.Max_XY.Y)
                }
            });

            // Add SL & T lines
            MarkBreakpoints(PiecewiseGraph, graph);

            // Add exposures
            Series exposure;
            for (int i = 0; i < newGraph.Exposures.Count; i++)
            {
                exposure = new Series
                {
                    Name = $"Series {i+1}",
                    ChartType = SeriesChartType.Line
                };

                foreach (Point point in newGraph.Exposures[i].DataPoints)
                {
                    exposure.Points.AddXY(point.X, point.Y);
                }

                PiecewiseGraph.Series.Add(exposure);
            }

            SetUpDowns();
        }

        public static void MarkBreakpoints(Chart chart, Graph graph, int borderWidth = 2)
        {
            List<Series> breakpoints = new List<Series>();
            breakpoints.Add(MakeBreakpoint("SL1", new Point(0, graph.KneePoints.LeftKneePoint.Y), new Point(graph.Max_XY.X, graph.KneePoints.LeftKneePoint.Y)));
            breakpoints.Add(MakeBreakpoint("SL2", new Point(0, graph.KneePoints.RightKneePoint.Y), new Point(graph.Max_XY.X, graph.KneePoints.RightKneePoint.Y)));
            breakpoints.Add(MakeBreakpoint("T1", new Point(graph.KneePoints.LeftKneePoint.X, 0), new Point(graph.KneePoints.LeftKneePoint.X, graph.Max_XY.Y)));
            breakpoints.Add(MakeBreakpoint("T2", new Point(graph.KneePoints.RightKneePoint.X, 0), new Point(graph.KneePoints.RightKneePoint.X, graph.Max_XY.Y)));

            foreach (Series s in breakpoints)
            {
                chart.Series.Add(s);
            }
        }

        public static Series MakeBreakpoint(string name, Point point1, Point point2, int borderWidth = 2, Color? color = null)
        {
            Color defaultColor = Color.Black;

            Series breakpoint = new Series()
            {
                Name = name,
                ChartType = SeriesChartType.Line,
                BorderWidth = borderWidth,
                BorderDashStyle = ChartDashStyle.Dash,
                Color = color ?? defaultColor
            };
            breakpoint.Points.AddXY(point1.X, point1.Y);
            breakpoint.Points.AddXY(point2.X, point2.Y);

            return breakpoint;
        }

        #region UpDowns
        public void SetUpDowns()
        {
            decimal powTenOfMaxX = (int)Math.Floor(Math.Log10((double)graph.Max_XY.X));
            decimal powTenOfMaxY = (int)Math.Floor(Math.Log10((double)graph.Max_XY.Y));

            decimal xScaling = graph.Max_XY.X * (decimal)Math.Pow(10, (double)(-powTenOfMaxX));
            decimal yScaling = graph.Max_XY.Y * (decimal)Math.Pow(10, (double)(-powTenOfMaxY));

            exposureTime_UpDown.Maximum = (decimal)Math.Pow(10, (double)powTenOfMaxX + 2);
            exposureTime_UpDown.Value = (graph.Max_XY.X);

            kneeOneX_UpDown.Maximum = graph.Max_XY.X;
            kneeOneX_UpDown.Value = graph.KneePoints.LeftKneePoint.X;
            kneeOneX_UpDown.Increment = xScaling * (decimal)Math.Pow(10, (double)powTenOfMaxX - 3);
            kneeOneX_UpDown.DecimalPlaces = (int)Math.Max(0, 4 - powTenOfMaxX);

            kneeOneY_UpDown.Maximum = graph.Max_XY.Y;
            kneeOneY_UpDown.Value = graph.KneePoints.LeftKneePoint.Y;
            kneeOneY_UpDown.Increment = yScaling * (decimal)Math.Pow(10, (double)powTenOfMaxY - 3);
            kneeOneY_UpDown.DecimalPlaces = (int)Math.Max(0, 4 - powTenOfMaxY);

            kneeTwoX_UpDown.Maximum = graph.Max_XY.X;
            kneeTwoX_UpDown.Value = graph.KneePoints.RightKneePoint.X;
            kneeTwoX_UpDown.Increment = kneeOneX_UpDown.Increment;
            kneeTwoX_UpDown.DecimalPlaces = kneeOneX_UpDown.DecimalPlaces;

            kneeTwoY_UpDown.Maximum = graph.Max_XY.Y;
            kneeTwoY_UpDown.Value = graph.KneePoints.RightKneePoint.Y;
            kneeTwoY_UpDown.Increment = kneeOneY_UpDown.Increment;
            kneeTwoY_UpDown.DecimalPlaces = kneeOneY_UpDown.DecimalPlaces;
        }

        private void exposureTime_UpDown_ValueChanged(object sender, EventArgs e)
        {
            Point newMax = new Point(exposureTime_UpDown.Value, graph.Max_XY.Y);
            if (!newMax.Equals(graph.Max_XY))
            {
                if (!relationship_CheckBox.Checked)
                {
                    if (KneePoints.ValidKneePoints(graph.KneePoints, newMax))
                    {
                        graph.SetupGraph(graph.KneePoints, newMax);
                        UpdateChart(graph);
                    }
                    else
                    {
                        exposureTime_UpDown.Value = graph.Max_XY.X;
                    }
                }
                else // Preserve the relationship between a0, a1, and a2
                {
                    decimal leftKneeProportion = graph.KneePoints.LeftKneePoint.X / graph.Max_XY.X;
                    decimal rightKneeProportion = graph.KneePoints.RightKneePoint.X / graph.Max_XY.X;

                    Point newLeftKnee = new Point(leftKneeProportion * newMax.X, graph.KneePoints.LeftKneePoint.Y);
                    Point newRightKnee = new Point(rightKneeProportion * newMax.X, graph.KneePoints.RightKneePoint.Y);

                    if (KneePoints.ValidKneePoints(newLeftKnee, newRightKnee, newMax))
                    {
                        graph.SetupGraph(newLeftKnee, newRightKnee, newMax);
                        UpdateChart(graph);
                    }
                    else
                    {
                        exposureTime_UpDown.Value = graph.Max_XY.X;
                    }
                }
            }
        }

        private void slope_UpDown_ValueChanged(object sender, EventArgs e)
        {
            SingleExposureGraph seg = new SingleExposureGraph();
            seg.SetupGraph(graph.KneePoints, graph.Max_XY);

            double theta = Graph.DegreesToRadians((double)slope_UpDown.Value);
            double slopeNormalization = (double)(graph.Max_XY.Y / graph.Max_XY.X);
            seg.AddExposure((decimal)(Math.Tan(theta) * slopeNormalization));

            graph = seg;
            UpdateChart(graph);
        }

        private void kneeOneX_UpDown_ValueChanged(object sender, EventArgs e)
        {
            Point newKnee = new Point(kneeOneX_UpDown.Value, graph.KneePoints.LeftKneePoint.Y);
            if (!newKnee.Equals(graph.KneePoints.LeftKneePoint))
            {

                if (KneePoints.ValidKneePoints(newKnee, graph.KneePoints.RightKneePoint, graph.Max_XY))
                {
                    graph.SetupGraph(newKnee, graph.KneePoints.RightKneePoint, graph.Max_XY);
                    UpdateChart(graph);
                }
                else
                {
                    kneeOneX_UpDown.Value = graph.KneePoints.LeftKneePoint.X;
                }
            }
        }

        private void kneeOneY_UpDown_ValueChanged(object sender, EventArgs e)
        {
            Point newKnee = new Point(graph.KneePoints.LeftKneePoint.X, kneeOneY_UpDown.Value);
            if (!newKnee.Equals(graph.KneePoints.LeftKneePoint))
            {

                if (KneePoints.ValidKneePoints(newKnee, graph.KneePoints.RightKneePoint, graph.Max_XY))
                {
                    graph.SetupGraph(newKnee, graph.KneePoints.RightKneePoint, graph.Max_XY);
                    UpdateChart(graph);
                }
                else
                {
                    kneeOneY_UpDown.Value = graph.KneePoints.LeftKneePoint.Y;
                }
            }
        }

        private void kneeTwoX_UpDown_ValueChanged(object sender, EventArgs e)
        {
            Point newKnee = new Point(kneeTwoX_UpDown.Value, graph.KneePoints.RightKneePoint.Y);
            if (!newKnee.Equals(graph.KneePoints.RightKneePoint))
            {

                if (KneePoints.ValidKneePoints(graph.KneePoints.LeftKneePoint, newKnee, graph.Max_XY))
                {
                    graph.SetupGraph(graph.KneePoints.LeftKneePoint, newKnee, graph.Max_XY);
                    UpdateChart(graph);
                }
                else
                {
                    kneeTwoX_UpDown.Value = graph.KneePoints.RightKneePoint.X;
                }
            }
        }

        private void kneeTwoY_UpDown_ValueChanged(object sender, EventArgs e)
        {
            Point newKnee = new Point(graph.KneePoints.RightKneePoint.X, kneeTwoY_UpDown.Value);
            if (!newKnee.Equals(graph.KneePoints.RightKneePoint))
            {
                if (KneePoints.ValidKneePoints(graph.KneePoints.LeftKneePoint, newKnee, graph.Max_XY))
                {
                    graph.SetupGraph(graph.KneePoints.LeftKneePoint, newKnee, graph.Max_XY);
                    UpdateChart(graph);
                }
                else
                {
                    kneeTwoY_UpDown.Value = graph.KneePoints.RightKneePoint.Y;
                }
            }
        }
        #endregion

        private void Exposure_CheckedChanged(object sender, EventArgs e)
        {
            if (multipleExposures_RadioButton.Checked)
            {
                MultipleExposureGraph newGraph = new MultipleExposureGraph();
                newGraph.SetupGraph(graph.KneePoints, graph.Max_XY);

                newGraph.SetMultipleExposures();

                graph = newGraph;
                UpdateChart(graph);
            }
            else
            {
                SingleExposureGraph seg = new SingleExposureGraph();
                seg.SetupGraph(graph.KneePoints, graph.Max_XY);

                double theta = Graph.DegreesToRadians((double)slope_UpDown.Value);
                double slopeNormalization = (double)(graph.Max_XY.Y / graph.Max_XY.X);
                seg.AddExposure((decimal)(Math.Tan(theta) * slopeNormalization));

                graph = seg;
                UpdateChart(graph);

            }
            newExposures_Button.Enabled = multipleExposures_RadioButton.Checked;
            slope_UpDown.Enabled = singleExposure_RadioButton.Checked;
        }

        private void newExposures_Button_Click(object sender, EventArgs e)
        {

            MultipleExposureGraph meg = (MultipleExposureGraph)graph;
            meg.ClearExposures();
            meg.SetMultipleExposures();

            graph = meg;
            UpdateChart(graph);
        }

        private void relationship_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            kneeOneX_UpDown.Enabled = !relationship_CheckBox.Checked;
            kneeOneY_UpDown.Enabled = !relationship_CheckBox.Checked;
            kneeTwoX_UpDown.Enabled = !relationship_CheckBox.Checked;
            kneeTwoY_UpDown.Enabled = !relationship_CheckBox.Checked;
        }
    }
}
