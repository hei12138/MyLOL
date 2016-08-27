using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace MyLOL.Controls
{
    public sealed class HeadSelecter : Control
    {
        private Point currentPoint; //最新的，当前的点
        private Point oldPoint;//上一个点
        private bool isPoint = false;


        public HeadSelecter()
        {
            this.DefaultStyleKey = typeof(HeadSelecter);
        }
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

        }
    }
}
