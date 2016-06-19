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
    public sealed class ColorDisplayer : Control
    {
        const double winpro = 0.3;
        public ColorDisplayer()
        {
            this.DefaultStyleKey = typeof(ColorDisplayer);
            
        }

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

        private double winPro;
        public double WinPro
        {
            get { return winPro; }
            set { winPro = value; }
        }


        ////好像是Get方法没有起作用
        ////底部中间点
        //public Point Interpointbottom
        //{
        //    get { return (Point)GetValue(InterpointbottomProperty); }
        //    set { SetValue(InterpointbottomProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for ClassRoom.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty InterpointbottomProperty =
        //    DependencyProperty.RegisterAttached("Interpointbottom", typeof(Point), typeof(ColorDisplayer), new PropertyMetadata(new Point(150, 40)));


        ////顶部中间点
        //public static Point GetInterpointtop(DependencyObject obj)
        //{
        //    return (Point)obj.GetValue(InterpointtopProperty);
        //}


        //public static void SetInterpointtop(DependencyObject obj, Point value)
        //{
        //    obj.SetValue(InterpointtopProperty, value);
        //}

        //// Using a DependencyProperty as the backing store for ClassRoom.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty InterpointtopProperty =
        //    DependencyProperty.RegisterAttached("Interpointtop", typeof(Point), typeof(ColorDisplayer), new PropertyMetadata(new Point(140, 0)));


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
