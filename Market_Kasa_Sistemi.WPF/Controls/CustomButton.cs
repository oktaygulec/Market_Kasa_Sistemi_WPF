using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Market_Kasa_Sistemi.WPF.Controls
{
    public class CustomButton : Button
    {
        public SolidColorBrush HoverColor
        {
            get { return (SolidColorBrush)GetValue(HoverColorProperty); }
            set { SetValue(HoverColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HoverColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HoverColorProperty =
            DependencyProperty.Register("HoverColor", typeof(SolidColorBrush), typeof(CustomButton), new PropertyMetadata(Brushes.Gray));

        public SolidColorBrush FocusedColor
        {
            get { return (SolidColorBrush)GetValue(FocusedColorProperty); }
            set { SetValue(FocusedColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FocusedColor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FocusedColorProperty =
            DependencyProperty.Register("FocusedColor", typeof(SolidColorBrush), typeof(CustomButton), new PropertyMetadata(Brushes.DarkGray));





        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(CustomButton), new PropertyMetadata(new CornerRadius(0)));




    }
}
