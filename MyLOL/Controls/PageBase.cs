using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace MyLOL.Controls
{
    public class PageBase : Page
    {
        private TranslateTransform _tt;

        private int action;
        public PageBase()
        {
            this.ManipulationMode = ManipulationModes.TranslateX;
            this.ManipulationCompleted += BasePage_ManipulationCompleted;
            this.ManipulationDelta += BasePag_ManipulationDelta;
            
            
            _tt = this.RenderTransform as TranslateTransform;
            if (_tt == null)
            {
                //似乎是在这里将位移值给页面
                this.RenderTransform = _tt = new TranslateTransform();
            }
            
        }
        //在此加入向左滑动的动画
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var s = new Storyboard();
            var doubleanimation = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromMilliseconds(160)),
                //此处由于OnNavigateTo获取不到ActualWidth，故设置为400
                //test
                From = 400,
                To = 0
            };
            Storyboard.SetTarget(doubleanimation, _tt);
            Storyboard.SetTargetProperty(doubleanimation, "X");
            s.Children.Add(doubleanimation);
            s.Begin();
        }
        private void BasePag_ManipulationDelta(object sender, ManipulationDeltaRoutedEventArgs e)
        {
            if (_tt.X + e.Delta.Translation.X < 0)
            {
                _tt.X = 0;
                return;
            }
            _tt.X += e.Delta.Translation.X;
            this.IsEnabled = false;
        }

        private void BasePage_ManipulationCompleted(object sender, ManipulationCompletedRoutedEventArgs e)
        {

            //操作x的位移绝对值
            double abs_delta = Math.Abs(e.Cumulative.Translation.X);
            //X轴的直线速度
            double speed = Math.Abs(e.Velocities.Linear.X);
            double delta = e.Cumulative.Translation.X;
            double to = 0;
            //滑动时保证其不可用//滑动完成后可用
            this.IsEnabled = true;

            //如果滑动距离小于实际宽度的1/3并且滑动速度小于0.5
            //就不让页面跳转
            if (abs_delta < this.ActualWidth / 3 && speed < 0.5)
            {
                _tt.X = 0;
                return;
            }

            action = 0;

            if (delta > 0)
            {
                to = this.ActualWidth;
            }
            else if (delta < 0)
            {
                return;
            }
            var s = new Storyboard();
            var doubleanimation = new DoubleAnimation()
            {
                Duration = new Duration(TimeSpan.FromMilliseconds(120)),
                From = _tt.X,
                To = to
            };
            doubleanimation.Completed += Doubleanimation_Completed;
            Storyboard.SetTarget(doubleanimation, _tt);
            Storyboard.SetTargetProperty(doubleanimation, "X");
            s.Children.Add(doubleanimation);
            s.Begin();
        }

        private void Doubleanimation_Completed(object sender, object e)
        {
            if (action == 0)
            {
                //this.Frame.GoBack();
                this.Frame.Content = null;
                //在这里进行动画结束后的操作
            }
            _tt = this.RenderTransform as TranslateTransform;
            if (_tt == null)
                this.RenderTransform = _tt = new TranslateTransform();
            _tt.X = 0;
        }
    }
}