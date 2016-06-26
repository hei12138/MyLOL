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
    public sealed class FlipView1 : FlipView
    {
        public FlipView1()
        {
            this.DefaultStyleKey = typeof(FlipView);
           
        }
        protected override void OnPointerWheelChanged(PointerRoutedEventArgs e)
        {
            e.Handled = true;
        }
    }
}
