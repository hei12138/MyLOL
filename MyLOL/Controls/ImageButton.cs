using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace MyLOL.Controls
{
    public sealed class ImageButton : Button
    {
        public ImageButton()
        {
            this.DefaultStyleKey = typeof(ImageButton);
            //Click += ImageButton_Click;
        }

        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            VisualStateManager.GoToState(this, "Clicked", false);
        }

        public Stretch ImageStretch
        {
            get { return (Stretch)GetValue(ImageStretchProperty); }
            set { SetValue(ImageStretchProperty, value); }
        }

        public static readonly DependencyProperty ImageStretchProperty = DependencyProperty.Register("ImageStretch", typeof(Stretch), typeof(ImageButton), new PropertyMetadata(Stretch.Uniform));

        public ImageSource ImageSourceNormal
        {
            get { return (ImageSource)GetValue(ImageSourceNormalProperty); }
            set { SetValue(ImageSourceNormalProperty, value); }
        }
        public static readonly DependencyProperty ImageSourceNormalProperty = DependencyProperty.Register("ImageSourceNormal", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(null));


        public ImageSource ImageSourcePressed
        {
            get { return (ImageSource)GetValue(ImageSourcePressedProperty); }
            set { SetValue(ImageSourcePressedProperty, value); }
        }
        public static readonly DependencyProperty ImageSourcePressedProperty = DependencyProperty.Register("ImageSourcePressed", typeof(ImageSource), typeof(ImageButton), new PropertyMetadata(null));

    }
}
