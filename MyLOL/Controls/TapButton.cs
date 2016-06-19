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
using Windows.UI.Xaml.Media.Imaging;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace MyLOL.Controls
{
    public sealed class TapButton : Button
    {
        public TapButton()
        {
            this.DefaultStyleKey = typeof(TapButton);
        }


        //图片的Source附加属性
        public static BitmapImage GetSource(DependencyObject obj)
        {
            return (BitmapImage)obj.GetValue(SourceProperty);
        }

        public static void SetSource(DependencyObject obj, BitmapImage value)
        {
            obj.SetValue(SourceProperty, value);
        }

        // Using a DependencyProperty as the backing store for ClassRoom.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.RegisterAttached("Source", typeof(BitmapImage), typeof(TapButton), new PropertyMetadata(null));



        public static string GetText(DependencyObject obj)
        {
            return (string)obj.GetValue(TextProperty);
        }

        public static void SetText(DependencyObject obj, string value)
        {
            obj.SetValue(TextProperty, value);
        }

        // Using a DependencyProperty as the backing store for ClassRoom.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.RegisterAttached("Text", typeof(string), typeof(TapButton), new PropertyMetadata(null));
    }
}
