using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DualSpinnerControl.Views
{
    internal class Arc : Shape
    {
        #region Dependency Properties



        public bool IsInner
        {
            get { return (bool)GetValue(IsInnerProperty); }
            set { SetValue(IsInnerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsInner.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsInnerProperty =
            DependencyProperty.Register("IsInner", typeof(bool), typeof(Arc), new PropertyMetadata(false));



        public double StartAngle
        {
            get { return (double)GetValue(StartAngleProperty); }
            set { SetValue(StartAngleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StartAngle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartAngleProperty =
            DependencyProperty.Register("StartAngle", typeof(double), typeof(Arc), new UIPropertyMetadata(0.0, new PropertyChangedCallback(UpdateArc)));

        public double EndAngle
        {
            get { return (double)GetValue(EndAngleProperty); }
            set { SetValue(EndAngleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EndAngle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EndAngleProperty =
            DependencyProperty.Register("EndAngle", typeof(double), typeof(Arc), new UIPropertyMetadata(360.0, new PropertyChangedCallback(UpdateArc)));

        //This controls whether or not the progress bar goes clockwise or counterclockwise
        public SweepDirection Direction
        {
            get { return (SweepDirection)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(SweepDirection), typeof(Arc),
                new UIPropertyMetadata(SweepDirection.Clockwise));

        //rotate the start/endpoint of the arc a certain number of degree in the direction
        //ie. if you wanted it to be at 12:00 that would be 270 Clockwise or 90 counterclockwise
        public double OriginRotationDegrees
        {
            get { return (double)GetValue(OriginRotationDegreesProperty); }
            set { SetValue(OriginRotationDegreesProperty, value); }
        }

        public static readonly DependencyProperty OriginRotationDegreesProperty =
            DependencyProperty.Register("OriginRotationDegrees", typeof(double), typeof(Arc),
                new UIPropertyMetadata(270.0, new PropertyChangedCallback(UpdateArc)));

        protected static void UpdateArc(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Arc arc = d as Arc;
            arc.InvalidateVisual();
        }

        #endregion

        #region Methods - Overridden

        protected override Geometry DefiningGeometry
        {
            get { return GetArcGeometryFromAngles(); }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            drawingContext.DrawGeometry(null, new Pen(Stroke, StrokeThickness), GetArcGeometryFromAngles());
        }

        #endregion

        #region Methods - Private

        private Geometry GetArcGeometryFromAngles()
        {
            Point startPoint = PointAtAngle(Math.Min(StartAngle, EndAngle), Direction); // angle to start drawing from
            Point endPoint = PointAtAngle(Math.Max(StartAngle, EndAngle), Direction); // angle to end drawing to

            double dblArcWidth = Math.Max(0, (RenderSize.Width - StrokeThickness) / 2);
            double dblArcHeight = Math.Max(0, (RenderSize.Height - StrokeThickness) / 2);

            Size arcSize = new Size(dblArcWidth, dblArcHeight);
            bool isLargeArc = Math.Abs(EndAngle - StartAngle) > 180;

            StreamGeometry geom = new StreamGeometry();
            using (StreamGeometryContext context = geom.Open())
            {
                context.BeginFigure(startPoint, false, false);
                context.ArcTo(endPoint, arcSize, 0, isLargeArc, Direction, true, false);
            }

            // set the transform for the geometry
            double dblTranslateX = (StrokeThickness / 2);
            double dblTranslateY = (StrokeThickness / 2);
            
            geom.Transform = new TranslateTransform(dblTranslateX, dblTranslateY);

            return geom;
        }

        private Point PointAtAngle(double angle, SweepDirection drawDirection)
        {
            double translatedAngle = angle + OriginRotationDegrees;
            double dblRadianAngle = translatedAngle * (Math.PI / 180);
            double dblRadiusX = (RenderSize.Width - StrokeThickness);
            double dblRadiusY = (RenderSize.Height - StrokeThickness);

            if(IsInner)
            {
                // inner arc is smaller
                dblRadiusX -= 10;
                dblRadiusY -= 10;
            }

            dblRadiusX /= 2;
            dblRadiusY /= 2;

            double xPos = dblRadiusX + dblRadiusX * Math.Cos(dblRadianAngle);
            double yPos = dblRadiusY * Math.Sin(dblRadianAngle);

            if (drawDirection == SweepDirection.Counterclockwise)
            {
                yPos = dblRadiusY - yPos;
            }
            else
            {
                yPos = dblRadiusY + yPos;
            }

            return new Point(xPos, yPos);
        }

        #endregion
    }
}