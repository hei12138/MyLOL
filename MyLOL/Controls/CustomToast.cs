using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace MyLOL.Controls
{
    public class CustomToast
    {
        #region Filed
        Grid toastGrid; //消息
        Border toastBorder;//用于圆角的Border
        Panel popUpParentPanel; //消息在此Panel上弹出
        Frame RootVisualFrame;  //当前页面的可视根
        TranslateTransform toastTransform;  //动画
        Duration dua = TimeSpan.FromMilliseconds(600);
        Timer timer = null;
        int seconds = 3;
        bool bLocked;
        bool bInit;
        #endregion

        #region Events

        public event EventHandler<object> ToastShowComplated;
        public event EventHandler<object> ToastHiddenCompleted;

        #endregion

        #region Properties

        public string Title { get; set; }
        public string Message { get; set; }
        public double TitleFontSize { get; set; }
        public double MessageFontSize { get; set; }
        public Orientation TextOrientation { get; set; }

        public bool IsShow { get; private set; }    //只能读 不能写
        public int TotalHiddenSeconds
        {
            get { return this.seconds; }
            set
            {
                if (seconds < 0)
                {
                    return;
                }
                else
                {
                    this.seconds = value;
                }
            }
        }
        public Panel PopUpParentPanel
        {
            get
            {
                if (popUpParentPanel == null)
                {
                    IEnumerable<ContentPresenter> source = CommonHelper.GetVisualDescendants(this.RootVisualFrame).OfType<ContentPresenter>();
                    int aaa = source.Count<ContentPresenter>();

                    for (int i = 0; i < source.Count<ContentPresenter>(); i++)
                    {
                        IEnumerable<Panel> enumerable2 = CommonHelper.GetVisualDescendants(source.ElementAt<ContentPresenter>(i)).OfType<Panel>();
                        if (enumerable2.Count<Panel>() > 0)
                        {
                            this.popUpParentPanel = enumerable2.First<Panel>();
                            break;
                        }
                    }
                }
                return this.popUpParentPanel;
            }
        }
        #endregion

        #region Construction
        //构造函数的继承  先执行后面的  后执行前面的   代码复用

        public CustomToast()
            : this(string.Empty, string.Empty)
        {

        }

        public CustomToast(string message)
            : this(string.Empty, message)
        {

        }
        public CustomToast(string title, string message)
        {
            this.Title = title;
            this.Message = message;

            TitleFontSize = MessageFontSize = 18;
            TextOrientation = Orientation.Horizontal;

        }

        #endregion

        #region Public Method

        public void Show()
        {
            if (bLocked)
            {
                return;
            }

            InitControl();

            if (PopUpParentPanel != null)
            {
                if (PopUpParentPanel is StackPanel)
                {
                    PopUpParentPanel.Children.Insert(0, toastGrid);
                }
                else
                {
                    PopUpParentPanel.Children.Add(toastGrid);
                }
                ShowStoryboard();
                bLocked = true;
            }
        }

        #endregion

        #region InitControl

        public void InitControl()
        {
            if (bInit)
            {
                return;
            }
            bInit = true;

            RootVisualFrame = Window.Current.Content as Frame;
            Brush gridbrush = new SolidColorBrush(Colors.Transparent);
            Brush brush = (Brush)Application.Current.Resources["SystemControlBackgroundAccentBrush"];


            toastGrid = new Grid() {Height=50,Width=20*Message.Length, Background = gridbrush, VerticalAlignment = VerticalAlignment.Bottom, Margin=new Thickness (0,0,0,40), HorizontalAlignment = HorizontalAlignment.Center };
            toastBorder = new Border()
            {
                CornerRadius = new CornerRadius(5),
                Background = brush
            };
            //toastGrid.ManipulationDelta += toastGrid_ManipulationDelta;
            //toastGrid.ManipulationCompleted += toastGrid_ManipulationCompleted;
            toastTransform = new TranslateTransform();
            toastGrid.RenderTransform = toastTransform;

            StackPanel spContent = new StackPanel()
            {
                //Margin = new Thickness(10, 5, 0, 0),
                Orientation = this.TextOrientation,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            TextBlock txtTitle = new TextBlock() { FontSize = TitleFontSize, Text = Title, VerticalAlignment = VerticalAlignment.Center };
            TextBlock txtMessage = new TextBlock() { FontSize = MessageFontSize, Text = Message, VerticalAlignment = VerticalAlignment.Center };

            if (spContent.Orientation == Orientation.Horizontal)
            {
                txtMessage.Margin = new Thickness(0, 0, 0, 0);
            }
            //垂直时改变height
            else
            {
                toastGrid.Height = 76;
            }

            spContent.Children.Add(txtTitle);
            spContent.Children.Add(txtMessage);
            toastBorder.Child = spContent;
            toastGrid.Children.Add(toastBorder);
        }
        #endregion

        #region ToastGrid Manipulation

        //void toastGrid_ManipulationDelta(object sender, Windows.UI.Xaml.Input.ManipulationDeltaRoutedEventArgs e)
        //{
        //    toastTransform.X = this.toastTransform.X + e.Delta.Translation.X;
        //    if (toastTransform.X < 0)
        //    {
        //        toastTransform.X = 0;
        //    }
        //}

        //void toastGrid_ManipulationCompleted(object sender, Windows.UI.Xaml.Input.ManipulationCompletedRoutedEventArgs e)
        //{
        //    if (e.Cumulative.Translation.X < 60)
        //    {
        //        toastTransform.X = 0;
        //    }
        //    else
        //    {
        //        HideStoryboard(toastTransform.X);
        //    }
        //}

        #endregion

        #region Storyboard & Timer

        public void ShowStoryboard()
        {
            Storyboard sbShow = new Storyboard();
            sbShow.Completed += sbShow_Completed;

            ///X轴方向从消息界面一半处开始动画
            DoubleAnimation da = new DoubleAnimation() { From = toastGrid.Width / 2, To = 0, Duration = dua };
            da.EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut };
            Storyboard.SetTarget(da, toastTransform);
            Storyboard.SetTargetProperty(da, "TranslateTransform.X");
            sbShow.Children.Add(da);

            //设置透明度从0变为1
            DoubleAnimation da1 = new DoubleAnimation() { From = 0, To = 1, Duration = dua };
            Storyboard.SetTarget(da1, toastGrid);
            Storyboard.SetTargetProperty(da1, "FrameworkElement.Opacity");
            sbShow.Children.Add(da1);

            sbShow.Begin();
        }

        void sbShow_Completed(object sender, object e)
        {
            IsShow = true;

            timer = new Timer(new TimerCallback(Time_Completed), null, this.TotalHiddenSeconds * 1000, 0);
            if (this.ToastShowComplated != null)
            {
                ToastShowComplated(this, e);
            }
        }

        async void Time_Completed(object e)
        {
            timer.Dispose();
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                HideStoryboard();
            });
        }
        private void HideStoryboard(double From = 0)
        {
            Storyboard sbHide = new Storyboard();
            sbHide.Completed += sbHide_Completed;
            DoubleAnimation da = new DoubleAnimation() { From = From, To = toastGrid.Width / 2, Duration = dua };
            Storyboard.SetTarget(da, toastTransform);
            Storyboard.SetTargetProperty(da, "TranslateTransform.X");
            sbHide.Children.Add(da);

            DoubleAnimation da1 = new DoubleAnimation() { From = 1, To = 0, Duration = dua };
            Storyboard.SetTarget(da1, toastGrid);
            Storyboard.SetTargetProperty(da1, "FrameworkElement.Opacity");
            sbHide.Children.Add(da1);

            sbHide.Begin();
        }

        void sbHide_Completed(object sender, object e)
        {
            IsShow = false;
            bLocked = false;

            if (toastGrid.Parent != null && toastGrid.Parent is Panel)
            {
                (toastGrid.Parent as Windows.UI.Xaml.Controls.Panel).Children.Remove(toastGrid);
            }

            if (ToastHiddenCompleted != null)
            {
                ToastHiddenCompleted(this, e);
            }
        }
        #endregion
    }
}

