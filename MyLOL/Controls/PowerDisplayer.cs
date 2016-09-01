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
using Windows.UI.Xaml.Shapes;

// The Templated Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234235

namespace MyLOL.Controls
{
    public sealed class PowerDisplayer : Control
    {
        public PowerDisplayer()
        {
            this.DefaultStyleKey = typeof(PowerDisplayer);
        }
        protected override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var rootcanvas = GetTemplateChild("rootcanvas") as Canvas;
            Polygon p = new Polygon();
            var s = new PointCollection();
            //0,-100 78,-62 97,22 43,90 -43,90 -97,22 -78,-62"ee5f49
            //刺杀
            s.Add(new Windows.Foundation.Point(0*Kill, -100*Kill));
            s.Add(new Windows.Foundation.Point(78*Live, -62*Live));
            s.Add(new Windows.Foundation.Point(97*Assist, 22*Assist));
            s.Add(new Windows.Foundation.Point(43*Physic, 90*Physic));
            s.Add(new Windows.Foundation.Point(-43*Magic, 90*Magic));
            s.Add(new Windows.Foundation.Point(-97*Defense, 22*Defense));
            s.Add(new Windows.Foundation.Point(-78*Money, -62*Money));
            p.Points = s;
            p.Stroke = new SolidColorBrush(Color.FromArgb(255, 238, 95, 73));
            rootcanvas.Children.Add(p);
        }


        private double kill;

        public double Kill
        {
            get { return kill; }
            set { kill = value; }
        }

        //助攻
        private double live;

        public double Live
        {
            get { return live; }
            set { live = value; }
        }

        //生存
        private double assist;

        public double Assist
        {
            get { return assist; }
            set { assist = value; }
        }

        //物理
        private double physic;

        public double Physic
        {
            get { return physic; }
            set { physic = value; }
        }
        //魔法
        private double magic;

        public double Magic
        {
            get { return magic; }
            set { magic = value; }
        }

        //防御
        private double defense;

        public double Defense
        {
            get { return defense; }
            set { defense = value; }
        }


        //金钱
        private double money;

        public double Money
        {
            get { return money; }
            set { money = value; }
        }




    }

}
