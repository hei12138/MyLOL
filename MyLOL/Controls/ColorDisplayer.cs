using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace MyLOL.Controls
{
    public sealed class ColorDisplayer : Control
    {
        public ColorDisplayer()
        {
            this.DefaultStyleKey = typeof(ColorDisplayer);
            
        }


        //TODO 实现长度可控

        protected override void OnApplyTemplate()
        {
            
            base.OnApplyTemplate();
            var rightTop = GetTemplateChild("rightTop") as LineSegment;
            rightTop.Point = new Point(200 * WinPro, 0);
            var rightBottom = GetTemplateChild("rightBottom") as PathFigure;
            rightBottom.StartPoint = new Point((200 * WinPro + 20) >= 200 ? 200 : (200 * WinPro + 20), 40);
            var lefttop = GetTemplateChild("leftTop") as LineSegment;
            lefttop.Point = new Point(200 * WinPro, 0);
            var leftbottom = GetTemplateChild("leftBottom") as LineSegment;
            leftbottom.Point = new Point((200 * WinPro+20)>=200?200: (200 * WinPro + 20), 40);
           
        }

        public Brush ColorBrush
        {
            get { return (Brush)GetValue(ColorBrushProperty); }
            set { SetValue(ColorBrushProperty, value); }
        }
        public static readonly DependencyProperty ColorBrushProperty = DependencyProperty.Register("ColorBrush", typeof(Brush), typeof(ColorDisplayer), new PropertyMetadata(new SolidColorBrush(Colors.Green)));


        public Brush ColorBrushBack
        {
            get { return (Brush)GetValue(ColorBrushBackProperty); }
            set { SetValue(ColorBrushBackProperty, value); }
        }
        public static readonly DependencyProperty ColorBrushBackProperty = DependencyProperty.Register("ColorBrushBack", typeof(Brush), typeof(ColorDisplayer), new PropertyMetadata(new SolidColorBrush(Colors.Gray)));


        private double winPro;
        public double WinPro
        {
            get { return winPro; }
            set { winPro = value; }
        }

        //胜率信息
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
            DependencyProperty.RegisterAttached("Text", typeof(string), typeof(ColorDisplayer), new PropertyMetadata(null));

    }
}
