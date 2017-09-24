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

namespace CustomSpinner
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomSpinner"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:CustomSpinner;assembly=CustomSpinner"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class CustomerSpinner : Control
    {
        static CustomerSpinner()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomerSpinner), new FrameworkPropertyMetadata(typeof(CustomerSpinner)));
        }



        public Color FillColor
        {
            get { return (Color)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FillColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FillColorProperty =
            DependencyProperty.Register("FillColor", typeof(Color), typeof(CustomerSpinner), 
                new PropertyMetadata((Color)ColorConverter.ConvertFromString("#25a6f7")));




        public Color UnFilledColor
        {
            get { return (Color)GetValue(UnFilledColorProperty); }
            set { SetValue(UnFilledColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UnFilledColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnFilledColorProperty =
            DependencyProperty.Register("UnFilledColor", typeof(Color), typeof(CustomerSpinner), 
                new PropertyMetadata(Colors.Purple));


    }
}
