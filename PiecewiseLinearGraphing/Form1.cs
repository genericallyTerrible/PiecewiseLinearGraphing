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
            Point leftKneePoint = new Point((decimal)0.7, ((decimal)1 / 3));
            Point rightKneePoint = new Point((decimal)0.9, ((decimal)2 / 3));
            Point max_XY = new Point(1, 1);

            if (KneePoints.ValidKneePoints(leftKneePoint, rightKneePoint, max_XY))
            {
                MultipleExposureGraph newGraph = new MultipleExposureGraph();
                if (newGraph.SetupGraph(leftKneePoint, rightKneePoint, max_XY))
                {
                    decimal startVal = (decimal)0.125;
                    decimal incrementVal = (decimal)0.125;
                    decimal stopVal = newGraph.KneePoints.A2 + (3 * incrementVal);
                    newGraph.SetMultipleExposures(startVal, incrementVal, stopVal);

                    graph = newGraph;
                    setUpDowns();
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
                    Interval = (double)(newGraph.Max_XY.X / 4)
                },
                AxisY = new Axis()
                {
                    Minimum = 0,
                    Maximum = (double)newGraph.Max_XY.Y,
                    Interval = (double)(newGraph.Max_XY.Y / 4)
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
                    Name = $"Series {i}",
                    ChartType = SeriesChartType.Line
                };

                foreach (Point point in newGraph.Exposures[i].DataPoints)
                {
                    exposure.Points.AddXY(point.X, point.Y);
                }

                PiecewiseGraph.Series.Add(exposure);
            }
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
        public void setUpDowns()
        {
            kneeOneX_UpDown.Maximum = graph.Max_XY.X;
            kneeOneX_UpDown.Value = graph.KneePoints.LeftKneePoint.X;
            kneeOneY_UpDown.Maximum = graph.Max_XY.Y;
            kneeOneY_UpDown.Value = graph.KneePoints.LeftKneePoint.Y;
            kneeTwoX_UpDown.Maximum = graph.Max_XY.X;
            kneeTwoX_UpDown.Value = graph.KneePoints.RightKneePoint.X;
            kneeTwoY_UpDown.Maximum = graph.Max_XY.Y;
            kneeTwoY_UpDown.Value = graph.KneePoints.RightKneePoint.Y;
            exposureTime_UpDown.Maximum = 10000;
            exposureTime_UpDown.Value = (graph.Max_XY.X * 100);
        }

        private void slope_UpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            SingleExposureGraph seg = (SingleExposureGraph)graph;
            seg.ClearExposures();

            double theta = Graph.DegreesToRadians((double)slope_UpDown.Value);

            seg.AddExposure((decimal)Math.Tan(theta));

            graph = seg;
            UpdateChart(graph);
        }

        private void kneeOneX_UpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            Point newKnee = new Point(nud.Value, graph.KneePoints.LeftKneePoint.Y);
            if (KneePoints.ValidKneePoints(newKnee, graph.KneePoints.RightKneePoint, graph.Max_XY))
            {
                graph.SetupGraph(newKnee, graph.KneePoints.RightKneePoint, graph.Max_XY);
                UpdateChart(graph);
            }
            else
            {
                nud.Value = graph.KneePoints.LeftKneePoint.X;
            }
        }

        private void kneeOneY_UpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            Point newKnee = new Point(graph.KneePoints.LeftKneePoint.X, nud.Value);
            if (KneePoints.ValidKneePoints(newKnee, graph.KneePoints.RightKneePoint, graph.Max_XY))
            {
                graph.SetupGraph(newKnee, graph.KneePoints.RightKneePoint, graph.Max_XY);
                UpdateChart(graph);
            }
            else
            {
                nud.Value = graph.KneePoints.LeftKneePoint.Y;
            }
        }

        private void kneeTwoX_UpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            Point newKnee = new Point(nud.Value, graph.KneePoints.RightKneePoint.Y);
            if (KneePoints.ValidKneePoints(graph.KneePoints.LeftKneePoint, newKnee, graph.Max_XY))
            {
                graph.SetupGraph(graph.KneePoints.LeftKneePoint, newKnee, graph.Max_XY);
                UpdateChart(graph);
            }
            else
            {
                nud.Value = graph.KneePoints.RightKneePoint.X;
            }
        }

        private void kneeTwoY_UpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            Point newKnee = new Point(graph.KneePoints.RightKneePoint.X, nud.Value);
            if (KneePoints.ValidKneePoints(graph.KneePoints.LeftKneePoint, newKnee, graph.Max_XY))
            {
                graph.SetupGraph(graph.KneePoints.LeftKneePoint, newKnee, graph.Max_XY);
                UpdateChart(graph);
            }
            else
            {
                nud.Value = graph.KneePoints.RightKneePoint.Y;
            }
        }

        private void exposureTime_UpDown_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;
            Point newMax = new Point((nud.Value / 100), graph.Max_XY.Y);
            if (KneePoints.ValidKneePoints(graph.KneePoints, newMax))
            {
                graph.SetupGraph(graph.KneePoints.LeftKneePoint, graph.KneePoints.RightKneePoint, newMax);
                UpdateChart(graph);
            }
            else
            {
                nud.Value = graph.Max_XY.X * 100;
            }
        }
        #endregion

        private void Exposure_CheckedChanged(object sender, EventArgs e)
        {
            if (multipleExposures_RadioButton.Checked)
            {
                MultipleExposureGraph newGraph = new MultipleExposureGraph();
                newGraph.SetupGraph(graph.KneePoints, graph.Max_XY);

                decimal startVal = (decimal)0.125;
                decimal incrementVal = (decimal)0.125;
                decimal stopVal = graph.KneePoints.A2 + (3 * incrementVal);
                newGraph.SetMultipleExposures(startVal, incrementVal, stopVal);

                graph = newGraph;
                UpdateChart(graph);
            }
            else
            {
                SingleExposureGraph newGraph = new SingleExposureGraph();
                newGraph.SetupGraph(graph.KneePoints, graph.Max_XY);

                double theta = Graph.DegreesToRadians((double)slope_UpDown.Value);
                newGraph.AddExposure((decimal)Math.Tan(theta));

                graph = newGraph;
                UpdateChart(graph);

            }
            newExposures_Button.Enabled = multipleExposures_RadioButton.Checked;
            slope_UpDown.Enabled = singleExposure_RadioButton.Checked;
        }

        private void newExposures_Button_Click(object sender, EventArgs e)
        {
            decimal startVal = (decimal)0.125;
            decimal incrementVal = (decimal)0.125;
            decimal stopVal = graph.KneePoints.A2 + (3 * incrementVal);

            MultipleExposureGraph meg = (MultipleExposureGraph)graph;
            meg.ClearExposures();
            meg.SetMultipleExposures(startVal, incrementVal, stopVal);

            graph = meg;
            UpdateChart(graph);
        }
    }
}
