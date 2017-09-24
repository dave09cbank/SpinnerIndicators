using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DualSpinnerControl.Views
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:DualSpinnerControl"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:DualSpinnerControl;assembly=DualSpinnerControl"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:SpinnerControl/>
    ///
    /// </summary>
    public class SpinnerControl : Control
    {
        static SpinnerControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SpinnerControl), new FrameworkPropertyMetadata(typeof(SpinnerControl)));
        }
        
        public bool IsInner
        {
            get { return (bool)GetValue(IsInnerProperty); }
            set { SetValue(IsInnerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsInner.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsInnerProperty =
            DependencyProperty.Register("IsInner", typeof(bool), typeof(SpinnerControl), new PropertyMetadata(false));



        public SweepDirection Direction
        {
            get { return (SweepDirection)GetValue(DirectionProperty); }
            set { SetValue(DirectionProperty, value); }
        }

        public static readonly DependencyProperty DirectionProperty =
            DependencyProperty.Register("Direction", typeof(SweepDirection), typeof(SpinnerControl),
                new UIPropertyMetadata(SweepDirection.Clockwise));

        public Color FillColor
        {
            get { return (Color)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FillColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillColorProperty =
            DependencyProperty.Register("FillColor", typeof(Color), typeof(SpinnerControl), new PropertyMetadata(ColorConverter.ConvertFromString("#25a6f7")));



        public Brush StrokeBrush
        {
            get { return (Brush)GetValue(StrokeBrushProperty); }
            set { SetValue(StrokeBrushProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StrokeBrush.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeBrushProperty =
            DependencyProperty.Register("StrokeBrush", typeof(Brush), typeof(SpinnerControl), new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#25a6f7"))));




        public Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BackgroundColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackgroundColorProperty =
            DependencyProperty.Register("BackgroundColor", typeof(Color), typeof(SpinnerControl), new PropertyMetadata(ColorConverter.ConvertFromString("#009B9B9B")));


    }
}
