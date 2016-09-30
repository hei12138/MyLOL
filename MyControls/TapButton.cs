using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace MyControls
{
    public sealed class TapButton : Button
    {
        public TapButton()
        {
            this.DefaultStyleKey = typeof(TapButton);
        }


        public ImageSource ImageSourceNormal
        {
            get { return (ImageSource)GetValue(ImageSourceNormalProperty); }
            set { SetValue(ImageSourceNormalProperty, value); }
        }
        public static readonly DependencyProperty ImageSourceNormalProperty = DependencyProperty.Register("ImageSourceNormal", typeof(ImageSource), typeof(TapButton), new PropertyMetadata(null));


        public ImageSource ImageSourcePressed
        {
            get { return (ImageSource)GetValue(ImageSourcePressedProperty); }
            set { SetValue(ImageSourcePressedProperty, value); }
        }
        public static readonly DependencyProperty ImageSourcePressedProperty = DependencyProperty.Register("ImageSourcePressed", typeof(ImageSource), typeof(TapButton), new PropertyMetadata(null));


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ClassRoom.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.RegisterAttached("Text", typeof(string), typeof(TapButton), new PropertyMetadata(null));

        public double BackImageOpacity
        {
            get
            {
                return (double)GetValue(BackImageOpacityProperty);
            }
            set { SetValue(BackImageOpacityProperty, value); }
        }
        public static readonly DependencyProperty BackImageOpacityProperty = DependencyProperty.Register("BackImageOpacity", typeof(double), typeof(TapButton), new PropertyMetadata(0));


        public double ForeImageOpacity
        {
            get
            {
                return (double)GetValue(ForeImageOpacityProperty);
            }
            set { SetValue(ForeImageOpacityProperty, value); }
        }
        public static readonly DependencyProperty ForeImageOpacityProperty = DependencyProperty.Register("ForeImageOpacity", typeof(double), typeof(TapButton), new PropertyMetadata(1));


        private bool isClicked;

        public bool IsClicked
        {
            get { return isClicked; }
            set
            {
                if (isClicked != value)
                {
                    if (value)
                    {
                        SetValue(BackImageOpacityProperty, 1);
                        SetValue(ForeImageOpacityProperty, 0);
                        Foreground = new SolidColorBrush(Color.FromArgb(255, 68, 135, 194));
                    }
                    else
                    {
                        SetValue(BackImageOpacityProperty, 0);
                        SetValue(ForeImageOpacityProperty, 1);
                        Foreground = new SolidColorBrush(Colors.Black);
                    }
                    isClicked = value;
                }
            }
        }


    }
}
