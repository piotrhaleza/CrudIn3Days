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

namespace Bukma.Controls
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Bukma.Controls"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Bukma.Controls;assembly=Bukma.Controls"
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
    ///     <MyNamespace:ThreeStateButton/>
    ///
    /// </summary>
    public class ThreeStateButton : Button
    {
        static ThreeStateButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ThreeStateButton), new FrameworkPropertyMetadata(typeof(ThreeStateButton)));
        }

        #region Icon
        public ImageSource Icon
        {
            get { return (ImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly DependencyProperty IconProperty =
           DependencyProperty.Register("Icon", typeof(ImageSource), typeof(IconsButton), new PropertyMetadata(null));
        #endregion

        #region IconOver
        public ImageSource IconOver
        {
            get { return (ImageSource)GetValue(IconOverProperty); }
            set { SetValue(IconOverProperty, value); }
        }
        public static readonly DependencyProperty IconOverProperty =
           DependencyProperty.Register("IconOver", typeof(ImageSource), typeof(IconsButton), new PropertyMetadata(null));
        #endregion

        #region IconPress
        public ImageSource IconPress
        {
            get { return (ImageSource)GetValue(IconPressProperty); }
            set { SetValue(IconPressProperty, value); }
        }
        public static readonly DependencyProperty IconPressProperty =
           DependencyProperty.Register("IconPress", typeof(ImageSource), typeof(IconsButton), new PropertyMetadata(null));
        #endregion
    }
}
