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
    public sealed class ButtonForLOL : Button
    {
        public ButtonForLOL()
        {
            this.DefaultStyleKey = typeof(ButtonForLOL);
        }

        //主要文字附加属性
        public static string GetMainText(DependencyObject obj)
        {
            return (string)obj.GetValue(MainTextProperty);
        }

        public static void SetMainText(DependencyObject obj, string value)
        {
            obj.SetValue(MainTextProperty, value);
        }

        // Using a DependencyProperty as the backing store for ClassRoom.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MainTextProperty =
            DependencyProperty.RegisterAttached("MainText", typeof(string), typeof(ButtonForLOL), new PropertyMetadata(null));


        //次要文字附加属性
        public static string GetSecText(DependencyObject obj)
        {
            return (string)obj.GetValue(SecTextProperty);
        }

        public static void SetSecText(DependencyObject obj, string value)
        {
            obj.SetValue(SecTextProperty, value);
        }

        // Using a DependencyProperty as the backing store for ClassRoom.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SecTextProperty =
            DependencyProperty.RegisterAttached("SecText", typeof(string), typeof(ButtonForLOL), new PropertyMetadata(null));


    }
}
