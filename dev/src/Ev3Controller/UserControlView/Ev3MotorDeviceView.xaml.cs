using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Ev3Controller.UserControlView
{
    /// <summary>
    /// Ev3MotorDeviceView.xaml の相互作用ロジック
    /// </summary>
    public partial class Ev3MotorDeviceView : UserControl
    {
        public Ev3MotorDeviceView()
        {
            InitializeComponent();

            this.Visibility = Visibility.Hidden;
        }
        #region Properties and fields
        public static readonly DependencyProperty TargetOutputProperty =
            DependencyProperty.Register(
                "TargetOutput",
                typeof(double),
                typeof(Ev3MotorDeviceView),
                new PropertyMetadata(0d, TargetOutputValueChanged));
        public double TargetOutput
        {
            get { return (double)GetValue(TargetOutputProperty); }
            set { SetValue(TargetOutputProperty, value); }
        }
        private static void TargetOutputValueChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var DstView = d as Ev3MotorDeviceView;
            double NewValue = (double)e.NewValue;
            double NewValueAbs = Math.Abs(NewValue);
            CircleProgressBar.SetValue(ref DstView.ForegroundBar_CurrentOutput, NewValueAbs, true);
            CircleProgressBar.SetValue(ref DstView.BackgroundBar_CurrentOutput, NewValueAbs, false);

            if (NewValue > 0)
            {
                DstView.ForegroundBar_CurrentOutput.Stroke = new SolidColorBrush(Colors.DeepSkyBlue);
            }
            else
            {
                DstView.ForegroundBar_CurrentOutput.Stroke = new SolidColorBrush(Colors.DeepPink);
            }
        }

        public static readonly DependencyProperty CurrentOutputProperty = 
            DependencyProperty.Register(
                "CurrentOutput",
                typeof(double),
                typeof(Ev3MotorDeviceView),
                new PropertyMetadata(0d, CurrentOutputValueChanged));
        public double CurrentOutput
        {
            get { return (double)GetValue(CurrentOutputProperty); }
            set { SetValue(CurrentOutputProperty, value); }
        }
        private static void CurrentOutputValueChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var DstView = d as Ev3MotorDeviceView;
            double NewValue = (double)e.NewValue;
            double NewValueAbs = Math.Abs(NewValue);
            CircleProgressBar.SetValue(ref DstView.ForegroundBar_TargetOutput, NewValueAbs, true);
            CircleProgressBar.SetValue(ref DstView.BackgroundBar_TargetOutput, NewValueAbs, false);

            if (NewValue > 0)
            {
                DstView.ForegroundBar_TargetOutput.Stroke = new SolidColorBrush(Colors.DodgerBlue);
            }
            else
            {
                DstView.ForegroundBar_TargetOutput.Stroke = new SolidColorBrush(Colors.Fuchsia);
            }
        }
        #endregion

        #region Inner class : Circle progress bar.
        public class CircleProgressBar
        {
            /// <summary>Round angle(360 degree)</summary>
            private const double ROUND_ANGLE = 360d;

            /// <summary>Straight angle(180 degree)</summary>
            private const double STRAIGHT_ANGLE = 180d;

            /// <summary>Right angle(90 degree)</summary>
            private const double RIGHT_ANGLE = 90d;

            /// <summary>Offset of circle.</summary>
            private const double END_OFFSET = 0.001;

            /// <summary>Max angle of circle progress bar.</summary>
            private const double MAX_ANGLE = 270d;

            /// <summary>
            /// Draw Control
            /// </summary>
            /// <param name="Element"></param>
            /// <param name="ValueToSet"></param>
            /// <param name="IsFront"></param>
            public static void SetValue(ref System.Windows.Shapes.Path Element,
                double ValueToSet,
                bool IsFront)
            {
                double Thick = Element.StrokeThickness / 2d;
                var Fig = new System.Windows.Media.PathFigure()
                {
                    StartPoint = new Point(
                        Element.Width / 2,
                        Element.Height - Thick)//Draw the circle from bottom to up side.
                };

                double Angle = CalcAngle(ValueToSet);
                double Radius = (Element.Width / 2) - Thick;
                var EndPoint = CalcEndPoint(Angle, Radius);
                bool IsLargeArcFlg = Angle >= STRAIGHT_ANGLE;

                // Create Draw Control.
                var Seg = new ArcSegment()
                {
                    Point = new Point(EndPoint.X + Thick, EndPoint.Y + Thick),
                    Size = new Size(Radius, Radius),
                    IsLargeArc = IsFront ? IsLargeArcFlg : !IsLargeArcFlg,
                    SweepDirection = IsFront ? SweepDirection.Clockwise
                                             : SweepDirection.Counterclockwise,
                    RotationAngle = 0
                };

                //Setup control.
                Fig.Segments.Clear();
                Fig.Segments.Add(Seg);
                Element.Data = new PathGeometry(new PathFigure[] { Fig });
            }

            /// <summary>
            /// Convert value between 0 and 100 into angle in "radian" unit.
            /// </summary>
            /// <param name="Value"></param>
            /// <returns></returns>
            protected static double CalcAngle(double Value)
            {
                double Result = 0d;
                double Angle = Math.Floor(Value) * (MAX_ANGLE / 100);
                if (Angle <= 0)
                {
                    Result = END_OFFSET;
                }
                else if (Angle >= 360)
                {
                    Result = (ROUND_ANGLE - END_OFFSET);
                }
                else
                {
                    Result = Angle;
                }
                return Result;
            }

            /// <summary>
            /// Calcurate end point.
            /// </summary>
            /// <param name="Angle"></param>
            /// <param name="Radius"></param>
            /// <returns></returns>
            protected static Point CalcEndPoint(double Angle, double Radius)
            {
                double Radian = Math.PI * (Angle + RIGHT_ANGLE) / 180;
                double x = Radius + Radius * Math.Cos(Radian);
                double y = Radius + Radius * Math.Sin(Radian);

                return new Point(x, y);
            }
            #endregion
        }

        private void UserControl_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            bool NewValue = (bool)e.NewValue;
            if (NewValue)
            {
                this.Visibility = Visibility.Visible;
            }
            else
            {
                this.Visibility = Visibility.Hidden;
            }

        }
    }
}
